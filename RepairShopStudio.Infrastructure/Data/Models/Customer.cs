using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Customer;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.Customer;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(CustomerMain)]
    public class Customer
    {
        [Key]
        [Comment(CustomerId)]
        public int Id { get; set; }

        [Required]
        [StringLength(CustomerNameMaxLength)]
        [Comment(CustomerName)]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength)]
        [Comment(CustomerPhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        [Comment(CustomerEmail)]
        public string Email { get; set; } = null!;

        [Required]
        [Comment(CustomerIsCorporate)]
        public bool IsCorporate { get; set; }

        [StringLength(UicMaxLength)]
        [Comment(CustomerUic)]
        public string Uic { get; set; } = null!;

        [Comment(CustomerAddressId)]
        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [Comment(CustomerAddress)]
        public Address? Address { get; set; } = null!;

        [StringLength(ResponsiblePersonNameMaxLength)]
        [Comment(CustomerResponsiblePerson)]
        public string? ResponsiblePerson { get; set; } = null!;

        [Comment(CustomerVehicles)]
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
