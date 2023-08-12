using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static RepairShopStudio.Common.Constants.ModelConstraintConstants.Address;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.Address;
using static RepairShopStudio.Common.Constants.ViewModelErrorMessageConstatns;
using System.Diagnostics.CodeAnalysis;

namespace RepairShopStudio.Core.Models.Address
{
    [Comment(AddViewModelMain)]
    public class AddressAddViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredField)]
        [StringLength(AddressTextMaxLength, MinimumLength = AddressTextMinLength, ErrorMessage = AddressTextLength)]
        [Comment(AddViewModelAddressText)]
        public string AddressText { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [StringLength(TownNameMaxLength, MinimumLength = TownNameMinLength, ErrorMessage = TownNameLength)]
        [Comment(AddViewModelTownName)]
        public string TownName { get; set; } = null!;

        [Required(ErrorMessage = RequiredField)]
        [MaxLength(ZipCodeMaxLength, ErrorMessage = ZipCodeLength)]
        [Comment(AddViewModelZipCode)]
        public string ZipCode { get; set; } = null!;
    }
}
