using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.HealthService;

namespace PetHealthCenter.Core.Models.HealthService
{
    [Comment(ServiceViewModelmain)]
    public class HealthServiceViewModel : IServiceModel
    {
        [Comment(ServiceViewModelId)]
        public int Id { get; set; }

        [Comment(ServiceViewModelName)]
        public string Name { get; set; } = null!;

        [Comment(ServiceViewModelDescription)]
        public string Description { get; set; } = null!;

        [Comment(ServiceViewModelPrice)]
        public decimal Price { get; set; }

        [Comment(ServiceViewModelProductComponentId)]
        [Display(Name = "Product component")]
        public int ProductComponentId { get; set; }

        [Comment(ServiceViewModelProductComponent)]
        public string ProductComponent { get; set; } = null!;

        [Comment(ServiceViewModelProductComponents)]
        public IEnumerable<HealthServiceProductComponentModel> ProductComponents { get; set; }
            = new List<HealthServiceProductComponentModel>();
    }
}
