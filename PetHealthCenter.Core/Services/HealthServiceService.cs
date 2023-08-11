using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.Part;
using PetHealthCenter.Core.Models.HealthService;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Models;
using static PetHealthCenter.Common.Constants.ExceptionMessagesConstants;
using static PetHealthCenter.Common.Constants.LoggerMessageConstants;

namespace PetHealthCenter.Core.Services
{
    public class HealthServiceService : IHealthServiceService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly ILogger<HealthServiceService> logger;

        public HealthServiceService(
            ApplicationDbContext _context,
            IRepository _repo,
            ILogger<HealthServiceService> _logger)
        {
            context = _context;
            repo = _repo;
            logger = _logger;
        }

        /// <summary>
        /// Create health service
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Add new health service to Data-Base</returns>
        public async Task AddAsync(AddHealthServiceViewModel model)
        {
            var entity = new HealthService()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                ProductComponentId = model.ProductComponentId
            };

            if (entity == null)
            {
                logger.LogError(NullHealthService);
                throw new NullReferenceException(InvalidHealthServiceException);
            }

            await context.HealthServices.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all product components
        /// </summary>
        /// <returns>List of HealthServiceProductComponentModel for all product components</returns>
        public async Task<IEnumerable<HealthServiceProductComponentModel>> AllProductComponents()
        {
            return await repo.AllReadonly<ProductComponent>()
                .OrderBy(c => c.Name)
                .Select(c => new HealthServiceProductComponentModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        /// <summary>
        /// Get health service from Data-Base by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Set the service's property IsActive to false</returns>
        public async Task Delete(int id)
        {
            var service = await repo.All<HealthService>()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (service != null)
            {
                service.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a certain health service from Data-Base by it's Id and modifies it's properties value
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="model"></param>
        /// <returns>Updated health service</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<bool> Edit(int serviceId, HealthServiceViewModel model)
        {
            var service = await context.FindAsync<HealthService>(serviceId);

            if (service != null)
            {
                service.Name = model.Name;
                service.Description = model.Description;
                service.Price = model.Price;
                service.ProductComponentId = model.ProductComponentId;

                context.Update(service);
                context.SaveChanges();

                return true;
            }

            logger.LogError(GetDataUnsuccessfull);
            throw new InvalidOperationException(InvalidHealthServiceIdException);
        }

        /// <summary>
        /// Check if a health service with certain Id exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Boolean wich defines if the certain health service exits</returns>
        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<HealthService>()
                .AnyAsync(p => p.Id == id && p.IsActive);
        }

        /// <summary>
        /// Get all product components from Data-Base
        /// </summary>
        /// <returns>List of all product components</returns>
        public async Task<IEnumerable<ProductComponent>> GetProductComponentsAsync()
        {
            return await context.ProductComponents.ToListAsync();
        }

        /// <summary>
        /// Get details for a certain health service by it's Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>HealthServiceDetailsModel with inormation about a certain health service</returns>
        public async Task<HealthServiceDetailsModel> ServiceDetailsById(int id)
        {
            return await repo.AllReadonly<HealthService>()
                .Where(p => p.IsActive)
                .Where(p => p.Id == id)
                .Select(p => new HealthServiceDetailsModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ProductComponent = p.ProductComponent.Name
                })
                .FirstAsync();
        }

        /// <summary>
        /// Check if a product component with certain Id exists
        /// </summary>
        /// <param name="componentId"></param>
        /// <returns>Boolean wich defines if the certain animal componen exits</returns>
        public async Task<bool> ProductComponentExists(int componentId)
        {
            return await repo.AllReadonly<ProductComponent>()
                .AnyAsync(c => c.Id == componentId);
        }
    }
}
