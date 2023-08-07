using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Infrastructure.Data.Models.User;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Common;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.OperatingCard;

namespace PetHealthCenter.Infrastructure.Data.Models
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
        public int CustomerId { get; set; }
        [Comment(OperatingCardCustomer)]
        public Customer? Customer { get; set; }

        [Comment(OperatingCardApplicationUserId)]
        public Guid ApplicationUserId { get; set; }
        [Comment(OperatingCardApplicationUser)]
        public ApplicationUser? ApplicationUser { get; set; }

        [Comment(OperatingCardIsActive)]
        public bool IsActive { get; set; } = true;

        [Comment(OperatingCardPetId)]
        public int PetId { get; set; }

    }
}