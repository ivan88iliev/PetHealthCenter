using RepairShopStudio.Core.Models.OperatingCard;
using RepairShopStudio.Infrastructure.Data.Models;
using RepairShopStudio.Infrastructure.Data.Models.User;


namespace RepairShopStudio.Core.Contracts
{
    public interface IOperatingCardService
    {
        Task<IEnumerable<OperatingCardViewModel>> GetAllAsync();
        Task AddOperatingCardAsync(OperatingCardAddViewModel model);
        Task<IEnumerable<ApplicationUser>> GetMechanicsAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<IEnumerable<Vehicle>> GetCustomerVehicles(int customerId);
        Task<string> GetCustomerNameById(int cutomerId);
        Task<IEnumerable<Part>> GetPartsAsync();
        Task<IEnumerable<ShopService>> GetShopServicesAsync();
        Task MarkRepairAsFinishedAsync(int cardId, string userId);
        Task<IEnumerable<OperatingCardViewModel>> GetAllFinishedAsync();
    }
}
