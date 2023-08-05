using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.HealthProduct;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Product, stored in the shop's warehouse")]
    public class Product
    {
        [Key]
        [Comment("Id of the product")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(HealthProductNameMaxLength)]
        [Comment("The name of the product")]
        public string Name { get; set; } = null!;

        [StringLength(HealthProductImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [Comment("Product's availability")]
        [Range (1, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        [StringLength(HealthProductManufacturerNameMaxLength)]
        [Comment("Manufacturer's name of the product")]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [StringLength(HealthProductOriginalMpnMaxLength)]
        [Comment("Product's MPN by the manufacturer")]
        public string OriginalMpn { get; set; } = null!;

        [StringLength(HealthProductDescriptionMaxLength)]
        [Comment("Description of the product")]
        public string? Description { get; set; }

        [Required]
        [Comment("Delivery price (by the supplier)")]
        [Range(typeof(decimal), HealthProductPriceMinValue, HealthProductPriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18,2)]
        public decimal PriceBuy { get; set; }

        [Required]
        [Comment("Selling price (by the health center)")]
        [Range(typeof(decimal), HealthProductPriceMinValue, HealthProductPriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal PriceSell { get; set; }

        [Comment("Affected part of the pet, where the product may be used")]
        public Guid PetComponentId { get; set; }

        [ForeignKey(nameof(PetComponentId))]
        public MedicalComponent PetComponent { get; set; } = null!;

        [Comment("Collection of suppliers, selling the products")]
        public ICollection<SupplierMedicalComponent> SupplierProducts { get; set; } = new List<SupplierMedicalComponent>();

    }
}
