using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Models.Address;
using PetHealthCenter.Core.Models.Pet;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Common;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.Customer;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.Custommer;
using static PetHealthCenter.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace PetHealthCenter.Core.Models.CustomerModels
{
    [Comment(AddViewModelMain)]
    public class CustomerAddViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(CustomerNameMaxLength, MinimumLength = CustomerNameMinLength, ErrorMessage = CustomerNameLength)]
        [Comment(AddViewModelName)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [Phone(ErrorMessage = ValidPhoneNumber)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = CustomerPhoneNumberLength)]
        [Comment(AddViewModelPhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [EmailAddress(ErrorMessage = ValidEmail)]
        [StringLength(EmailMaxLength, ErrorMessage = EmailLength)]
        [Comment(AddViewModelEmail)]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [Comment(AddViewModelIsCorporate)]
        public bool IsCorporate { get; set; }

        [StringLength(UicMaxLength, MinimumLength =UicMinLength, ErrorMessage = UICLength)]
        [Comment(AddViewModelUic)]
        public string? Uic { get; set; }

        [StringLength(ResponsiblePersonNameMaxLength, ErrorMessage = ResponsiblePersonNameLength)]
        [Comment(AddViewModelResponsiblePerson)]
        public string? ResponsiblePerson { get; set; }

        [Comment(AddViewModelPet)]
        public PetAddViewModel? Pet { get; set; } = null!;

        [Comment(AddViewModelAddress)]
        public AddressAddViewModel? Address { get; set; }
    }
}
