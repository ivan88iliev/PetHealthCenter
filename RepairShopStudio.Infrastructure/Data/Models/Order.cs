using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Order;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Order of parts properties")]
    public class Order
    {
        [Key]
        [Comment("Id of the order")]
        public Guid Id { get; set; }

        [Required]
        [Comment("Document number")]
        public string Number { get; set; } = null!;

        [Required]
        [Comment("Date of the creation of the order")]
        public DateTime IssueDate { get; set; }

        [Required]
        [Comment("Collection of ordered products")]
        public ICollection<Product> Products { get; set; } = new List<Product>();

        [Required]
        [StringLength(OrderNoteMaxLength)]
        public string Note { get; set; } = null!;


        [Comment("Supplier which will deliver the goods")]
        public Guid SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier? Supplier { get; set; }
    }
}
