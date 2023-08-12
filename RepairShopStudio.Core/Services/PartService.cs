using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;
using static RepairShopStudio.Common.Constants.ExceptionMessagesConstants;
using static RepairShopStudio.Common.Constants.LoggerMessageConstants;

namespace RepairShopStudio.Core.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly ILogger<PartService> logger;

        public PartService(
            ApplicationDbContext _context,
            IRepository _repo,
            ILogger<PartService> _logger)
        {
            context = _context;
            repo = _repo;
            logger = _logger;
        }

        /// <summary>
        /// Create new part
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Add new part to Data-Base</returns>
        public async Task AddPartAsync(AddPartViewModel model)
        {
            var entity = new Part()
            {
                Id = model.Id,
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Manufacturer = model.Manufacturer,
                OriginalMpn = model.OriginalMpn,
                PriceSell = model.PriceSell,
                PriceBuy = model.PriceBuy,
                Stock = model.Stock,
                VehicleComponentId = model.VehicleComponentId
            };

            if (entity == null)
            {
                logger.LogError(NullPart);
                throw new InvalidOperationException(InvalidPartException);
            }

            await context.Parts.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Check if a part with certain Id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean wich defines if the certain part exits</returns>
        public async Task<bool> Exists(int id)
        {
            var result = await repo.AllReadonly<Part>()
                .AnyAsync(p => p.Id == id && p.IsActive);

            if (result == false)
            {
                logger.LogError(NullPart);
                throw new NullReferenceException(PartDoesNotExistExceptionMessage);
            }

            return result;
        }

        /// <summary>
        /// Get all parts from Data-Base
        /// </summary>
        /// <returns>List of all parts</returns>
        public async Task<IEnumerable<PartViewModel>> GetAllAsync()
        {
            var entities = await context.Parts
                .Where(p => p.IsActive)
                .Include(p => p.VehicleComponent)
                .ToListAsync();

            if (entities == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetPartsException);
            }

            return entities
                .Select(p => new PartViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                    Manufacturer = p.Manufacturer,
                    OriginalMpn = p.OriginalMpn,
                    Description = p.Description,
                    PriceSell = p.PriceSell,
                    PriceBuy= p.PriceBuy,
                    VehicleComponent = p.VehicleComponent.Name
                });
        }

        /// <summary>
        /// Get all vehicle components from Data-Base
        /// </summary>
        /// <returns>List of all vehicle components</returns>
        public async Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync()
        {
            var result = await context.VehicleComponents.ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetVehicleComponentsException);
            }

            return result;
        }

        /// <summary>
        /// Get a certain vehicle component by a part's Id
        /// </summary>
        /// <param name="partId"></param>
        /// <returns>Vehicle compnonent's Id</returns>
        public async Task<int> GetVehicleComponentId(int partId)
        {
            var result = (await repo.GetByIdAsync<Part>(partId)).VehicleComponentId;

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetPartVehicleComponentException);
            }
            return result;
        }

        /// <summary>
        /// Get details for a certain part by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PartDetailsModel with inormation about a certain Part</returns>
        public async Task<PartDetailsModel> PartDetailsById(int id)
        {
            var part =  await repo.AllReadonly<Part>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new PartDetailsModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Manufacturer = p.Manufacturer,
                    OriginalMpn = p.OriginalMpn,
                    PriceSell = p.PriceSell,
                    PriceBuy = p.PriceBuy,
                    Stock = p.Stock,
                    VehicleComponent = p.VehicleComponent.Name
                })
                .FirstAsync();

            if (part == null)
            {
                logger.LogError(NullPart);
                throw new InvalidOperationException(InvalidGetPartDeatalsException);
            }

            return part;
        }

        /// <summary>
        /// Get all vehicle components
        /// </summary>
        /// <returns>List of PartVehicleCopmonentModel for all vehicle components</returns>
        public async Task<IEnumerable<PartVehicleCopmonentModel>> AllVehicleComponents()
        {
            var result =  await repo.AllReadonly<VehicleComponent>()
                .OrderBy(c => c.Name)
                .Select(c => new PartVehicleCopmonentModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetVehicleComponentsException);
            }

            return result;
        }

        /// <summary>
        /// Check if a vehicle component with certain Id exists
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns>Boolean wich defines if the certain vehicle componen exits</returns>
        public async Task<bool> VehicleComponentExists(int componentId)
        {
            return await repo.AllReadonly<VehicleComponent>()
                .AnyAsync(c => c.Id == componentId);
        }

        /// <summary>
        /// Get a certain part from Data-Base by it's Id and modifies it's properties value
        /// </summary>
        /// <param name="partId"></param>
        /// <param name="model"></param>
        /// <returns>Updated part</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<bool> Edit(int partId, PartViewModel model)
        {
            var part = await context.FindAsync<Part>(partId);

            if (part != null)
            {
                part.Name = model.Name;
                part.OriginalMpn = model.OriginalMpn;
                part.Manufacturer = model.Manufacturer;
                part.PriceSell = model.PriceSell;
                part.PriceBuy = model.PriceBuy;
                part.Stock = model.Stock;
                part.Description = model.Description;
                part.ImageUrl = model.ImageUrl;
                part.VehicleComponentId = model.VehicleComponentId;

                context.Update(part);
                context.SaveChanges();

                return true;
            }

            logger.LogError(NullPart);
            throw new InvalidOperationException(InvalidPartIdException);

        }

        /// <summary>
        /// Get a certain part by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>EditPartViewModel with loaded information about a certain part</returns>
        /// <exception cref="NullReferenceException"></exception>
        public async Task<EditPartViewModel> GetPartForEditAsync(int id)
        {
            
            var part = context.Parts.Find(id);

            if (part != null)
            {
                var result = new EditPartViewModel()
                {
                    Id = part.Id,
                    Name = part.Name,
                    Description = part.Description,
                    ImageUrl = part.ImageUrl,
                    VehicleComponentId = part.VehicleComponentId,
                    OriginalMpn = part.OriginalMpn,
                    Stock = part.Stock,
                    Manufacturer = part.Manufacturer,
                    PriceSell = part.PriceSell,
                    PriceBuy = part.PriceBuy,
                    VehicleComponents = await GetVehicleComponentsAsync()
                };

                return result;
            }

            logger.LogError(NullPart);
            throw new NullReferenceException(InvalidPartIdException);
        }

        /// <summary>
        /// Get part from Data-Base by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Part</returns>
        public async Task<Part> GetPartById(int id)
        {
            var result = await context.Parts.FirstOrDefaultAsync(p => p.Id == id);

            if (result == null)
            {
                logger.LogError(NullPart);
                throw new InvalidOperationException(InvalidPartIdException);
            }

            return result;

        }

        /// <summary>
        /// Get part from Data-Base by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Set the part's property IsActive to false</returns>
        public async Task Delete(int id)
        {
            var part = await repo.All<Part>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (part != null)
            {
                part.IsActive = false;

                await repo.SaveChangesAsync();
            }
            else
            {
                logger.LogError(NullPart);
                throw new NullReferenceException(InvalidPartIdException);
            }
        }

        /// <summary>
        /// Create parts query model for pagination, search and sorting options
        /// </summary>
        /// <param name="vehicleComponent"></param>
        /// <param name="manufacturer"></param>
        /// <param name="searchTerm"></param>
        /// <param name="sorting"></param>
        /// <param name="currentPage"></param>
        /// <param name="housesPerPage"></param>
        /// <returns>List of all parts in data-base</returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PartsFilterQueryModel> AllAsync(string? vehicleComponent = null, string? manufacturer = null, string? searchTerm = null, PartSorting sorting = PartSorting.Newest, int currentPage = 1, int partsPerPage = 1)
        {
            var result = new PartsFilterQueryModel();
            var parts = repo.AllReadonly<Part>()
                .Where(p => p.IsActive);

            //if (parts == null)
            //{
            //    logger.LogError(GetDataUnsuccessfull);
            //    throw new NullReferenceException(InvalidGetPartsException);
            //}

            if (string.IsNullOrEmpty(vehicleComponent) == false)
            {
                parts = parts
                    .Where(p => p.VehicleComponent.Name == vehicleComponent);
            }

            if (string.IsNullOrEmpty(manufacturer) == false)
            {
                parts = parts
                    .Where(p => p.Manufacturer == manufacturer);
            }

            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                parts = parts
                    .Where(p => EF.Functions.Like(p.Name.ToLower(), searchTerm) ||
                        EF.Functions.Like(p.Manufacturer.ToLower(), searchTerm) ||
                        EF.Functions.Like(p.Description.ToLower(), searchTerm));
            }

            parts = sorting switch
            {
                PartSorting.Price => parts.OrderBy(p => p.PriceSell),
                _ => parts.OrderByDescending(p => p.Id)
            };

            result.Parts = await parts
                .Skip((currentPage - 1) * partsPerPage)
                .Take(partsPerPage)
                .Select(p => new PartServiceModel()
                {
                    Id = p.Id,
                    Description = p.Description,
                    Manufacturer = p.Manufacturer,
                    ImageUrl = p.ImageUrl,
                    Stock = p.Stock,
                    PriceSell = p.PriceSell,
                    PriceBuy = p.PriceBuy,
                    Name = p.Name,
                    OriginalMpn = p.OriginalMpn,
                    VehicleComponent = p.VehicleComponent.Name
                })
                .ToListAsync();

            result.TotalPartsCount = await parts.CountAsync();

            return result;
        }

        /// <summary>
        /// Get all vehicle components name
        /// </summary>
        /// <returns>List of all vehicle component name</returns>
        public async Task<IEnumerable<string>> AllVehicleComponentsNames()
        {
            var result = await repo.AllReadonly<Part>()
                .Select(p => p.VehicleComponent.Name)
                .Distinct()
                .ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetVehicleComponentsException);
            }

            return result; 
        }

        /// <summary>
        /// Geta all parts manufacturers
        /// </summary>
        /// <returns>List of all parts manufacturers</returns>
        public async Task<IEnumerable<string>> AllManufacturers()
        {
            var result = await repo.AllReadonly<Part>()
                .Select(c => c.Manufacturer)
                .Distinct()
                .ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetManufacturersException);
            }

            return result;
        }
    }
}
