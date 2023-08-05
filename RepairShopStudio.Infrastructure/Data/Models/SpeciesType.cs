using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Breed;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("Type of the specie")]
    public class SpeciesType
    {
        [Key]
        [Comment("Id of the specie type")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(BreedTypeNameMaxLength)]
        [Comment("Name of specie type")]
        public string Name { get; set; } = null!;

    }
}
