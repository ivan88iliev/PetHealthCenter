using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.MedicalComponent;

namespace PetHealthCenter.Infrastructure.Data.Models
{
    [Comment("The components/parts of the animal, which can be affected by the services")]
    public class MedicalComponent
    {
        [Key]
        [Comment("Id of the animal service component")]
        public Guid Id { get; set; }

        [Required]
        [StringLength(MedicalComponentNameMaxLength)]
        [Comment("Name of animal component")]
        public string Name { get; set; } = null!;

    }
}
