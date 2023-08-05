using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Address;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Addres properties")]
    public class Address
    {
        [Key]
        [Comment("Id of the address")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(AddressTextMaxLength)]
        [Comment("Adrres text - street, number, etc.")]
        public string AddressText { get; set; } = null!;

        [Required]
        [MaxLength(AddressTextMaxLength)]
        [Comment("Town name")]
        public string TownName { get; set; } = null!;

        [Required]
        [MaxLength(ZipCodeMaxLength)]
        [Comment("ZIP code of the town")]
        public string ZipCode { get; set; } = null!;
    }
}
