using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Supplier;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using System.ComponentModel.DataAnnotations.Schema;
using static RepairShopStudio.Common.Constants.DbModelCommentConstants.Supplier;

namespace RepairShopStudio.Infrastructure.Data.Models
{
    [Comment(SupplierMain)]
    public class Supplier
    {
        [Key]
        [Comment(SupplierId)]
        public int Id { get; set; }

        [Required]
        [StringLength(SupplierNameMaxLength)]
        [Comment(SupplierName)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SupplierCompanyNameMaxLength)]
        [Comment(SupplierCompanyName)]
        public string CompanyName { get; set; } = null!;

        [Required]
        [StringLength(UicMaxLength)]
        [Comment(SupplierUic)]
        public string Uic { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength)]
        [Comment(SupplierPhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        [Comment(SupplierEmail)]
        public string Email { get; set; } = null!;

        [Comment(SupplierSupplierSpareParts)]
        public ICollection<SupplierSparePart> SupplierSpareParts { get; set; } = new List<SupplierSparePart>();

        [Comment(SupplierAddressId)]
        public int AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [Comment(SupplierAddress)]
        public Address Address { get; set; } = null!;
    }
}
