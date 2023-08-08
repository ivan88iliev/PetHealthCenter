using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.HealthService;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.HealthService;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment(HealthServiceMain)]
    public class HealthService
    {
        [Key]
        [Comment(HealthServiceId)]
        public int Id { get; set; }

        [Required]
        [StringLength(RepairServiceNameMaxLength)]
        [Comment(HealthServiceName)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(RepairServiceDescriptionMaxLength)]
        [Comment(HealthServiceDescription)]
        public string Description { get; set; } = null!;

        [Required]
        [Comment(HealthServicePrice)]
        [Range(typeof(decimal), HealthServicePriceMinValue, HealthServicePriceMaxValue)]
        [Column(TypeName = "money")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Comment(HealthServiceProductComponentId)]
        public int ProductComponentId { get; set; }

        [ForeignKey(nameof(ProductComponentId))]
        [Comment(HealthServiceProductComponent)]
        public ProductComponent ProductComponent { get; set; } = null!;

        [Required]
        [Comment(HealthServiceParts)]
        public ICollection<Part> Parts { get; set; } = new List<Part>();

        [Comment(HealthServiceIsActive)]
        public bool IsActive { get; set; } = true;

    }
}