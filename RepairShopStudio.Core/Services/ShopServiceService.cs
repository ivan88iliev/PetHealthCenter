using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Core.Models.ShopService;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;
using static RepairShopStudio.Common.Constants.ExceptionMessagesConstants;
using static RepairShopStudio.Common.Constants.LoggerMessageConstants;

namespace RepairShopStudio.Core.Services
{
    public class ShopServiceService : IShopServiceService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly ILogger<ShopServiceService> logger;

        public ShopServiceService(
            ApplicationDbContext _context,
            IRepository _repo,
            ILogger<ShopServiceService> _logger)
        {
            context = _context;
            repo = _repo;
            logger = _logger;
        }

        /// <summary>
        /// Create shop service
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Add new shop service to Data-Base</returns>
        public async Task AddAsync(AddShopServiceViewModel model)
        {
            var entity = new ShopService()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                VehicleComponentId = model.VehicleComponentId
            };

            if (entity == null)
            {
                logger.LogError(NullShopService);
                throw new NullReferenceException(InvalidShopServiceException);
            }

            await context.ShopServices.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all vehicle components
        /// </summary>
        /// <returns>List of ShopServiceVehicleComponentModel for all vehicle components</returns>
        public async Task<IEnumerable<ShopServiceVehicleComponentModel>> AllVehicleComponents()
        {
            return await repo.AllReadonly<VehicleComponent>()
                .OrderBy(c => c.Name)
                .Select(c => new ShopServiceVehicleComponentModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// Get shop service from Data-Base by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Set the service's property IsActive to false</returns>
        public async Task Delete(int id)
        {
            var service = await repo.All<ShopService>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (service != null)
            {
                service.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a certain shop service from Data-Base by it's Id and modifies it's properties value
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="model"></param>
        /// <returns>Updated shop service</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<bool> Edit(int serviceId, ShopServiceViewModel model)
        {
            var service = await context.FindAsync<ShopService>(serviceId);

            if (service != null)
            {
                service.Name = model.Name;
                service.Description = model.Description;
                service.Price = model.Price;
                service.VehicleComponentId = model.VehicleComponentId;

                context.Update(service);
                context.SaveChanges();

                return true;
            }

            logger.LogError(GetDataUnsuccessfull);
            throw new InvalidOperationException(InvalidShopServiceIdException);
        }

        /// <summary>
        /// Check if a shop service with certain Id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean wich defines if the certain shop service exits</returns>
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<ShopService>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        /// <summary>
        /// Get all shop services from Data-Base
        /// </summary>
        /// <returns>List of all shop services</returns>
        public async Task<IEnumerable<ShopServiceViewModel>> GetAllAsync()
        {
            var entities = await context.ShopServices
                .Where(s => s.IsActive)
                .Include(s => s.VehicleComponent)
                .ToListAsync();

            if (entities == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new NullReferenceException(InvalidGetServicesException);
            }

            return entities
                .Select(p => new ShopServiceViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    VehicleComponent = p.VehicleComponent.Name
                });

           
        }

        /// <summary>
        /// Get a certain vehicle component by a service's Id
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>Vehicle compnonent's Id</returns>
        public async Task<int> GetVehicleComponentId(int serviceId)
        {
            return (await repo.GetByIdAsync<ShopService>(serviceId)).VehicleComponentId;
        }

        /// <summary>
        /// Get all vehicle components from Data-Base
        /// </summary>
        /// <returns>List of all vehicle components</returns>
        public async Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync()
        {
            return await context.VehicleComponents.ToListAsync();
        }

        /// <summary>
        /// Get details for a certain shop service by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ShopServiceDetailsModel with inormation about a certain shop service</returns>
        public async Task<ShopServiceDetailsModel> ServiceDetailsById(int id)
        {
            return await repo.AllReadonly<ShopService>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new ShopServiceDetailsModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    VehicleComponent = p.VehicleComponent.Name
                })
                .FirstAsync();
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
    }
}
