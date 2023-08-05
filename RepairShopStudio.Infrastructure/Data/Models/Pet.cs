using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Pet;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Pet, owned by customer")]
    public class Pet
    {
        [Key]
        [Comment("Id of the Pet")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(PetNameMaxLength)]
        [Comment("Pet breed name")]
        public string Breed { get; set; } = null!;

        [Required]
        [StringLength(PetSpeciesMaxLength)]
        [Comment("Pet specie name")]
        public string Specie { get; set; } = null!;

        [Required]
        [StringLength(AnimalIdentificationNumberMaxLength)]
        [Comment("Animal identification number")]
        public string AnimalIdentificationNumber { get; set; } = null!;

        [Required]
        [Comment("Birthday for the pet")]
        public DateTime PetBirthDay { get; set; }

        [Comment("Engine type of the vehicle")]
        public Guid SpecieTypeId { get; set; }

        [ForeignKey(nameof(SpecieTypeId))]
        public SpeciesType SpecieType { get; set; } = null!;

        [Required]
        [Range(PetMinWeight, PetMaxWeight)]
        [Comment("Pet weight")]
        public int Weight { get; set; }

        [Required]
        [StringLength(PetHealthCenter.Common.Constants.ModelConstraintConstants.Pet.HospitalizedNumber)]
        [Comment("Hospitalized number of the pet")]
        public string HospitalizedNumber { get; set; } = null!;

        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [Comment("Customer/owner of the vehicle")]
        public Customer? Customer { get; set; }

        public ICollection<HealthService> HOspitalizedHistory { get; set; } = new List<HealthService>();
    }
}
