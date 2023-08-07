using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Pet;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Pet;
using static PetHealthCenter.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace PetHealthCenter.Core.Models.Pet
{
    [Comment(AddViewModelMain)]
    public class PetAddViewModel
    {
        [Comment(AddViewModelId)]
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(PetMakeMaxLength, MinimumLength = PetMakeMinLength, ErrorMessage = PetMakeLength)]
        [Comment(AddViewModelMake)]
        public string? Make { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(PetModelMaxLength, MinimumLength = PetModelMinLength, ErrorMessage = PetModelLength)]
        [Comment(AddViewModelModel)]
        public string? Model { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(IdentificationNumberMaxLength, MinimumLength = IdentificationNumberMinLength, ErrorMessage = PetIdentificationNumberNumberLength)]
        [Comment(AddViewModelIdentificationNUmber)]
        public string? IdentificationNUmber { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelFIrstRegistration)]
        public DateTime FIrstRegistration { get; set; }

        [Comment(AddViewModelSpecieTypeId)]
        public int SpecieTypeId { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [Range(SpecieMinPower, SpecieMaxPower, ErrorMessage = PetPowerRange)]
        [Comment(AddViewModelPower)]
        public int Power { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(VinNumberLength, MinimumLength =VinNumberLength, ErrorMessage = PetVINRange)]
        [Comment(AddViewModelVinNumber)]
        public string? VinNumber { get; set; }

        [Comment(AddViewModelSpecieTypes)]
        public ICollection<Infrastructure.Data.Models.SpecieType> SpecieTypes { get; set; }
            = new List<Infrastructure.Data.Models.SpecieType>();

    }
}
