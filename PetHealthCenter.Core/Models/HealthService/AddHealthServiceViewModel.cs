using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PetHealthCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.HealthService;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.HealthService;
using static PetHealthCenter.Common.Constants.ViewModelErrorMessageConstatns;

namespace PetHealthCenter.Core.Models.HealthService
{
    [Comment(AddViewModelMain)]
    public class AddHealthServiceViewModel
    {
        public int Id { get; set; }

        [Comment(AddViewModelName)]
        [StringLength(RepairServiceNameMaxLength, MinimumLength = RepairServiceNameMinLength, ErrorMessage = ServiceNameLength)]
        public string Name { get; set; } = null!;

        [Comment(AddViewModelDescription)]
        [StringLength(
            RepairServiceDescriptionMaxLength, MinimumLength = RepairServiceDescriptionMinLength, ErrorMessage = ServiceDescriptionLength)]
        public string Description { get; set; } = null!;

        [Comment(AddViewModelPrice)]
        [Range(typeof(decimal), HealthServicePriceMinValue, HealthServicePriceMaxValue, ErrorMessage = ServicePriceRange)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Comment(AddViewModelProductComponentId)]
        public int ProductComponentId { get; set; }

        [Comment(AddViewModelProductComponents)]
        public IEnumerable<ProductComponent> ProductComponents { get; set; } = new List<ProductComponent>();
    }
}
