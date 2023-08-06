using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Common;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Operating card for the current service")]
    public class OperatingCard
    {
        [Key]
        [Comment("Id of the operating card")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Date of the creation of the document")]
        public DateTime Date { get; set; }

        [Required]
        [Comment("The number of current document")]
        [StringLength(DocumentNumberMaxLength)]
        public string DocumentNumber { get; set; } = null!;

        [Required]
        [Comment("Services, applied to current pet")]
        ICollection<HealthService> ShopServices { get; set; } = new List<HealthService>();

        [Required]
        [Comment("Products, needed for current service")]
        ICollection<Product> Products { get; set; } = new List<Product>();

        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer? Customer { get; set; }

        public Guid EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        [Required]
        [Range(1.0, 100.0)]
        public double Discount { get; set; }
    }
}
