using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Pet;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.Pet;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment(PetMain)]
    public class Pet
    {
        [Key]
        [Comment(PetId)]
        public int Id { get; set; }

        [Required]
        [StringLength(PetOriginMaxLength)]
        [Comment(PetOrigin)]
        public string Make { get; set; } = null!;

        [Required]
        [StringLength(PetModelMaxLength)]
        [Comment(PetModel)]
        public string Model { get; set; } = null!;

        [Required]
        [StringLength(IdentificationNumberMaxLength)]
        [Comment(PetIdentificationNumber)]
        public string IdentificationNUmber { get; set; } = null!;

        [Required]
        [Comment(PetFirstRegistration)]
        public DateTime FIrstRegistration { get; set; }

        [Comment(PetSpecieTypeId)]
        public int SpecieTypeId { get; set; }

        [ForeignKey(nameof(SpecieTypeId))]
        [Comment(PetSpecieType)]
        public SpecieType SpecieType { get; set; } = null!;

        [Required]
        [Range(SpecieMinWeight, SpecieMaxWeight)]
        [Comment(PetWeight)]
        public int Weight { get; set; }

        [Required]
        [StringLength(PetNumberLength)]
        [Comment(PetPetNumber)]
        public string PetNumber { get; set; } = null!;

        [Comment(PetCustomerId)]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [Comment(PetCustomer)]
        public Customer? Customer { get; set; }

    }
}
