using PetHealthCenter.Core.Models.CustomerModels;
using PetHealthCenter.Core.Models.SpecieType;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Core.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerViewModel>> GetAllAsync();

        Task<IEnumerable<SpecieTypeViewModel>> AllSpecieTypesAsync();

        Task AddRegularCutomerAsync(CustomerAddViewModel customerModel);

        Task AddCorporateCutomerAsync(CustomerAddViewModel customerModel);

        Task<IEnumerable<SpecieType>> GetSpecieTypesAsync();
    }
}
