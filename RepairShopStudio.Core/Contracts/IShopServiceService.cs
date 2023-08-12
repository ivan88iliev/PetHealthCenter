using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Core.Models.ShopService;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Core.Contracts
{
    public interface IShopServiceService
    {
        Task<IEnumerable<ShopServiceViewModel>> GetAllAsync();
        Task<IEnumerable<VehicleComponent>> GetVehicleComponentsAsync();
        Task AddAsync(AddShopServiceViewModel model);
        Task<bool> Exists(int id);
        Task<ShopServiceDetailsModel> ServiceDetailsById(int id);
        Task<int> GetVehicleComponentId(int serviceId);
        Task<IEnumerable<ShopServiceVehicleComponentModel>> AllVehicleComponents();
        Task<bool> VehicleComponentExists(int componentId);
        Task<bool> Edit(int serviceId, ShopServiceViewModel model);
        Task Delete(int id);
    }
}
