using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.OperatingCard;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(OperatingCardMain)]
    public class OperatingCard
    {
        [Key]
        [Comment(OperatingCardId)]
        public int Id { get; set; }

        [Required]
        [Comment(OperatingCardDate)]
        public DateTime Date { get; set; }

        [Required]
        [Comment(OperatingCardDocumentNumber)]
        [StringLength(DocumentNumberMaxLength)]
        public string DocumentNumber { get; set; } = null!;

        [Comment(OperatingCardPartId)]
        public int? PartId { get; set; }

        [Comment(OperatingCardPart)]
        public Part? Part { get; set; }

        [Comment(OperatingCardServiceId)]
        public int? ServiceId { get; set; }
        [Comment(OperatingCardService)]
        public ShopService? Service { get; set; }

        [Comment(OperatingCardCustomerId)]
        public int CustomerId { get; set; }
        [Comment(OperatingCardCustomer)]
        public Customer? Customer { get; set; }

        [Comment(OperatingCardApplicationUserId)]
        public Guid ApplicationUserId { get; set; }
        [Comment(OperatingCardApplicationUser)]
        public ApplicationUser? ApplicationUser { get; set; }

        [Comment(OperatingCardIsActive)]
        public bool IsActive { get; set; } = true;

        [Comment(OperatingCardVehicleId)]
        public int VehicleId { get; set; }

    }
}