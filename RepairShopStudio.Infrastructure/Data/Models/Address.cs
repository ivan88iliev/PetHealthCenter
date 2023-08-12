using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Address;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.Address;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(AddressMain)]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(AddressTextMaxLength)]
        [Comment(AddressAddressText)]
        public string AddressText { get; set; } = null!;

        [Required]
        [MaxLength(AddressTextMaxLength)]
        [Comment(AddressTownName)]
        public string TownName { get; set; } = null!;

        [Required]
        [MaxLength(ZipCodeMaxLength)]
        [Comment(AddressZipCode)]
        public string ZipCode { get; set; } = null!;
    }
}
