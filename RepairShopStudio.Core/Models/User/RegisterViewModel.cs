using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.User;

namespace RepairShopStudio.Core.Models.User
{
    [ExcludeFromCodeCoverage]
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Comment(RegisterViewModelUserName)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Comment(RegisterViewModelFirstName)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 3)]
        [Comment(RegisterViewModelLastName)]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        [Comment(RegisterViewModelEmail)]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Comment(RegisterViewModelPassword)]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Comment(RegisterViewModelConfirmPassword)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
