﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Supplier;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Supplier, who delivers parts to the repair shop")]
    public class Supplier
    {
        [Key]
        [Comment("Id of the supplier")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(SupplierNameMaxLength)]
        [Comment("Name of the supplier")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(SupplierCompanyNameMaxLength)]
        [Comment("Name of the supplier's company")]
        public string CompanyName { get; set; } = null!;

        [Required]
        [StringLength(UicMaxLength)]
        [Comment("Unit Identification Code of the supplier's company")]
        public string Uic { get; set; } = null!;

        [Required]
        [Phone]
        [StringLength(PhoneNumberMaxLength)]
        [Comment("Phone number of the supplier's office")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(EmailMaxLength)]
        [Comment("Email of the supplier")]
        public string Email { get; set; } = null!;

        [Comment("Collection of products, selled by the supplier")]
        public ICollection<SupplierMedicalComponent> SupplierProducts { get; set; } = new List<SupplierMedicalComponent>();

        [Comment("Address of the supplier's office")]
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; } = null!;
    }
}
