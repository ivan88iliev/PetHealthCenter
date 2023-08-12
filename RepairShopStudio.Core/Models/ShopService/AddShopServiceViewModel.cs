using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.ShopService;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.ShopService;
using static RepairShopStudio.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Models.ShopService
{
    [Comment(AddViewModelMain)]
    public class AddShopServiceViewModel
    {
        public int Id { get; set; }

        [Comment(AddViewModelName)]
        [StringLength(RepairServiceNameMaxLength, MinimumLength = RepairServiceNameMinLength, ErrorMessage = ServiceNameLength)]
        public string Name { get; set; } = null!;

        [Comment(AddViewModelDescription)]
        [StringLength (
            RepairServiceDescriptionMaxLength, MinimumLength = RepairServiceDescriptionMinLength, ErrorMessage = ServiceDescriptionLength)]
        public string Description { get; set; } = null!;

        [Comment(AddViewModelPrice)]
        [Range(typeof(decimal), ShopServicePriceMinValue, ShopServicePriceMaxValue, ErrorMessage = ServicePriceRange)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Comment(AddViewModelVehicleComponentId)]
        public int VehicleComponentId { get; set; }

        [Comment(AddViewModelVehicleComponents)]
        public IEnumerable<VehicleComponent> VehicleComponents { get; set; } = new List<VehicleComponent>();
    }
}
