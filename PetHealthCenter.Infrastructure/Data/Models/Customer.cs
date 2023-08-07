using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Customer;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Customer information")]
    public class Customer
    {
        [Key]
        [Comment("Customer Id")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(CustomerNameMaxLength)]
        [Comment("Name of the customer")]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength)]
        [Comment("Phone number of the cusotmer")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        [Comment("Email of the customer")]
        public string Email { get; set; } = null!;

        [Required]
        [Comment("Defines if the customer is corporate or individual")]
        public bool IsCorporate { get; set; }

        [StringLength(UicMaxLength)]
        [Comment("The Unit Identification Code of the customer's company")]
        public string Uic { get; set; } = null!;

        [Comment("The address of the customer's office")]
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; } = null!;

        [StringLength(ResponsiblePersonNameMaxLength)]
        [Comment("Name of the responsible person of the customer's company")]
        public string ResponsiblePerson { get; set; } = null!;

        [Comment("Collection of Pets, owned by the customer")]
        public ICollection<Pet> Pet { get; set; } = new List<Pet>();
    }
}
