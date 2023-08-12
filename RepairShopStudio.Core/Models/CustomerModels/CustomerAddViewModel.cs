using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Models.Address;
using RepairShopStudio.Core.Models.Vehicle;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Common;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Customer;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Custommer;
using static RepairShopStudio.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Models.CustomerModels
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

        [Comment(AddViewModelVehicle)]
        public VehicleAddViewModel? Vehicle { get; set; } = null!;

        [Comment(AddViewModelAddress)]
        public AddressAddViewModel? Address { get; set; }
    }
}
