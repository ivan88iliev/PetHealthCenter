using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.SparePart;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.Part;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment(PartMain)]
    public class Part
    {
        [Key]
        [Comment(PartId)]
        public int Id { get; set; }

        [Required]
        [StringLength(SparePartNameMaxLength)]
        [Comment(PartName)]
        public string Name { get; set; } = null!;

        [StringLength(SparePartImageUrlMaxLength)]
        [Comment(PartImageUrl)]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment(PartStock)]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        [StringLength(SparePartManufacturerNameMaxLength)]
        [Comment(PartManufacturer)]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(SparePartOriginalMpnMaxLength)]
        [Comment(PartOriginalMpn)]
        public string OriginalMpn { get; set; } = null!;

        [StringLength(SparePartDescriptionMaxLength)]
        [Comment(PartDescription)]
        public string? Description { get; set; }

        [Required]
        [Comment(PartPriceBuy)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal PriceBuy { get; set; }

        [Required]
        [Comment(PartPriceSell)]
        [Range(typeof(decimal), SparePartPriceMinValue, SparePartPriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal PriceSell { get; set; }

        [Required]
        [Comment(PartProductComponentId)]
        public int ProductComponentId { get; set; }

        [ForeignKey(nameof(ProductComponentId))]
        [Comment(PartProductComponent)]
        public ProductComponent ProductComponent { get; set; } = null!;

        [Comment(PartSupplierSpareParts)]
        public ICollection<SupplierSparePart> SupplierSpareParts { get; set; } = new List<SupplierSparePart>();

        [Comment(PartIsActive)]
        public bool IsActive { get; set; } = true;
    }
}