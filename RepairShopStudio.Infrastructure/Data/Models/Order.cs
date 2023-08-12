using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Order;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.Order;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(OrderMain)]
    public class Order
    {
        [Key]
        [Comment(OrderId)]
        public int Id { get; set; }

        [Required]
        [Comment(OrderNumber)]
        public string Number { get; set; } = null!;

        [Required]
        [Comment(OrderIssueDate)]
        public DateTime IssueDate { get; set; }

        [Required]
        [Comment(OrderParts)]
        public ICollection<Part> Parts { get; set; } = new List<Part>();

        [Required]
        [StringLength(OrderNoteMaxLength)]
        [Comment(OrderNote)]
        public string Note { get; set; } = null!;

        [Comment(OrderSupplierId)]
        public int SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        [Comment(OrderSupplier)]
        public Supplier? Supplier { get; set; }

        [Comment(OrderIsActive)]
        public bool IsActive { get; set; } = true;
    }
}
