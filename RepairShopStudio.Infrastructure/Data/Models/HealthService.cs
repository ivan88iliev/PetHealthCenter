using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.HealthService;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Services, offered by health center")]
    public class HealthService
    {
        [Key]
        [Comment("Id of the service")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(HealthServiceNameMaxLength)]
        [Comment("Name of the service")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(HealthServiceDescriptionMaxLength)]
        [Comment("Description of the service")]
        public string Description { get; set; } = null!;

        [Required]
        [Comment("Price of the service")]
        [Range(typeof(decimal), HealthServicePriceMinValue, HealthServicePriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Comment("Affected medical component")]
        public MedicalComponent MedicalComponent { get; set; } = null!;

        [Required]
        [Comment("Medical product needed for the service")]
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
