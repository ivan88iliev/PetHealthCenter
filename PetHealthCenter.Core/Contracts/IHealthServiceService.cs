using PetHealthCenter.Core.Models.Part;
using PetHealthCenter.Core.Models.HealthService;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Core.Contracts
{
    public interface IHealthServiceService
    {
        Task<IEnumerable<HealthServiceViewModel>> GetAllAsync();
        Task<IEnumerable<ProductComponent>> GetProductComponentsAsync();
        Task AddAsync(AddHealthServiceViewModel model);
        Task<bool> Exists(int id);
        Task<HealthServiceDetailsModel> ServiceDetailsById(int id);
        Task<int> GetProductComponentId(int serviceId);
        Task<IEnumerable<HealthServiceProductComponentModel>> AllProductComponents();
        Task<bool> ProductComponentExists(int componentId);
        Task<bool> Edit(int serviceId, HealthServiceViewModel model);
        Task Delete(int id);
    }
}
