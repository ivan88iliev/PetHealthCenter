using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.SparePart;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Part;
using static RepairShopStudio.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Models.Part
{
    [Comment(AddViewModelMain)]
    public class AddPartViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelId)]
        public int Id { get; set; }

        [Comment(AddViewModelName)]
        [StringLength(SparePartNameMaxLength, MinimumLength = SparePartNameMinLength, ErrorMessage = PartNameLength)]
        public string Name { get; set; } = null!;

        [Comment(AddViewModelImageUrl)]
        [StringLength(SparePartImageUrlMaxLength, MinimumLength = SparePartImageUrlMinLength, ErrorMessage = PartImageUrlLength)]
        public string? ImageUrl { get; set; }

        [Comment(AddViewModelStock)]
        [Range(0, int.MaxValue, ErrorMessage = PartStockLength)]
        public int Stock { get; set; }

        [Comment(AddViewModelManufacturer)]
        [StringLength(SparePartManufacturerNameMaxLength, MinimumLength = SparePartManufacturerNameMinLength, ErrorMessage = PartManufacturerNameLength)]
        public string Manufacturer { get; set; } = null!;

        [Comment(AddViewModelOriginalMpn)]
        [StringLength(SparePartOriginalMpnMaxLength, MinimumLength = SparePartOriginalMpnMinLength, ErrorMessage = PartMPNLength)]
        public string OriginalMpn { get; set; } = null!;

        [Comment(AddViewModelDescription)]
        [StringLength(SparePartDescriptionMaxLength, MinimumLength = SparePartDescriptionMinLength, ErrorMessage = PartDescriptionNameLength)]
        public string? Description { get; set; }

        [Comment(AddViewModelPriceBuy)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue, ErrorMessage = PartPriceRange)]
        public decimal PriceBuy { get; set; }

        [Comment(AddViewModelPriceSell)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue, ErrorMessage = PartPriceRange)]
        public decimal PriceSell { get; set; }

        [Comment(AddViewModelVehicleComponentId)]
        public int VehicleComponentId { get; set; }

        [Comment(AddViewModelVehicleComponents)]
        public IEnumerable<VehicleComponent> VehicleComponents { get; set; } = new List<VehicleComponent>();
    }
}
