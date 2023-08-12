using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.SparePart;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Part;
using static PetHealthCenter.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace PetHealthCenter.Core.Models.Part
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

        [Comment(AddViewModelProductComponentId)]
        public int ProductComponentId { get; set; }

        [Comment(AddViewModelProductComponents)]
        public IEnumerable<ProductComponent> ProductComponents { get; set; } = new List<ProductComponent>();
    }
}
