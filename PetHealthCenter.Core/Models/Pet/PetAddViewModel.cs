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
        [StringLength(PetOriginMaxLength, MinimumLength = PetOriginMinLength, ErrorMessage = PetOriginLength)]
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
        [Range(SpecieMinWeight, SpecieMaxWeight, ErrorMessage = PetWeightRange)]
        [Comment(AddViewModelWeight)]
        public int Weight { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(PetNumberLength, MinimumLength =PetNumberLength, ErrorMessage = PetVINRange)]
        [Comment(AddViewModelPetNumber)]
        public string? PetNumber { get; set; }

        [Comment(AddViewModelSpecieTypes)]
        public ICollection<Infrastructure.Data.Models.SpecieType> SpecieTypes { get; set; }
            = new List<Infrastructure.Data.Models.SpecieType>();

    }
}
