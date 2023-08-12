using PetHealthCenter.Core.Models.Part;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Core.Contracts
{
    public interface IPartService
    {
        Task<IEnumerable<PartViewModel>> GetAllAsync();

        Task<IEnumerable<ProductComponent>> GetProductComponentsAsync();

        Task AddPartAsync(AddPartViewModel model);

        Task<bool> Exists(int id);

        Task<PartDetailsModel> PartDetailsById(int id);

        Task<int> GetProductComponentId(int partId);

        Task<IEnumerable<PartProductComponentModel>> AllProductComponents();

        Task<bool> ProductComponentExists(int componentId);

        Task<bool> Edit(int partId, PartViewModel model);

        Task<EditPartViewModel> GetPartForEditAsync(int id);

        Task<Part> GetPartById(int id);

        Task Delete(int id);

        Task<PartsFilterQueryModel> AllAsync(
            string? animalComponent = null,
            string? manufacturer = null,
            string? searchTerm = null,
            PartSorting sorting = PartSorting.Newest,
            int currentPage = 1,
            int housesPerPage = 1);

        Task<IEnumerable<string>> AllProductComponentsNames();
        Task<IEnumerable<string>> AllManufacturers();
    }
}
