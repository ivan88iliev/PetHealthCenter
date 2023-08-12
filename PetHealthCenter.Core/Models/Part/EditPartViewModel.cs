using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.SparePart;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Part;
using static PetHealthCenter.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace PetHealthCenter.Core.Models.Part
{
    [Comment(EditViewModelMain)]
    public class EditPartViewModel
    {
        [Required(ErrorMessage = RequiredField)]
        [Comment(EditViewModelId)]
        public int Id { get; set; }

        [Comment(EditViewModelName)]
        [StringLength(SparePartNameMaxLength, MinimumLength = SparePartNameMinLength, ErrorMessage = PartNameLength)]
        public string Name { get; set; } = null!;

        [Comment(EditViewModelImageUrl)]
        [StringLength(SparePartImageUrlMaxLength, MinimumLength = SparePartImageUrlMinLength, ErrorMessage = PartImageUrlLength)]
        public string? ImageUrl { get; set; }

        [Comment(EditViewModelStock)]
        [Range(0, int.MaxValue, ErrorMessage = PartStockLength)]
        public int Stock { get; set; }

        [Comment(EditViewModelManufacturer)]
        [StringLength(SparePartManufacturerNameMaxLength, MinimumLength = SparePartManufacturerNameMinLength, ErrorMessage = PartManufacturerNameLength)]
        public string Manufacturer { get; set; } = null!;

        [Comment(EditViewModelOriginalMpn)]
        [StringLength(SparePartOriginalMpnMaxLength, MinimumLength = SparePartOriginalMpnMinLength, ErrorMessage = PartMPNLength)]
        public string OriginalMpn { get; set; } = null!;

        [Comment(EditViewModelDescription)]
        [StringLength(SparePartDescriptionMaxLength, MinimumLength = SparePartDescriptionMinLength, ErrorMessage = PartDescriptionNameLength)]
        public string? Description { get; set; }

        [Comment(EditViewModelPriceBuy)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue, ErrorMessage = PartPriceRange)]
        public decimal PriceBuy { get; set; }

        [Comment(EditViewModelPriceSell)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue, ErrorMessage = PartPriceRange)]
        public decimal PriceSell { get; set; }

        [Comment(EditViewModelProductComponentId)]
        public int ProductComponentId { get; set; }

        [Comment(EditViewModelProductComponents)]
        public IEnumerable<ProductComponent> ProductComponents { get; set; } = new List<ProductComponent>();
    }
}
