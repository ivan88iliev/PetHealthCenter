using PetHealthCenter.Core.Models.OperatingCard;
using PetHealthCenter.Infrastructure.Data.Models;
using PetHealthCenter.Infrastructure.Data.Models.User;


namespace PetHealthCenter.Core.Contracts
{
    public interface IOperatingCardService
    {
        Task<IEnumerable<OperatingCardViewModel>> GetAllAsync();
        Task AddOperatingCardAsync(OperatingCardAddViewModel model);
        Task<IEnumerable<ApplicationUser>> GetDoctorsAsync();
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<IEnumerable<Pet>> GetCustomerPets(int customerId);
        Task<string> GetCustomerNameById(int cutomerId);
        Task<IEnumerable<Part>> GetPartsAsync();
        Task MarkRepairAsFinishedAsync(int cardId, string userId);
        Task<IEnumerable<OperatingCardViewModel>> GetAllFinishedAsync();
    }
}
