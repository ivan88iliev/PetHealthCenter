using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PetHealthCenter.Common.Constants.ModelConstraintConstants.ApplicationUser;
using static PetHealthCenter.Common.Constants.DbModelCommentConstants.ApplicationUser;

namespace PetHealthCenter.Infrastructure.Data.Models.User
{
    [Comment(ApplicationUserMain)]
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Comment(ApplicationUserFirstName)]
        [StringLength(ApplicationUserFirstNameMaxLength)]
        public string? FirstName { get; set; }

        [Comment(ApplicationUserLastName)]
        [StringLength(ApplicationUserLastNameMaxLength)]
        public string? LastName { get; set; }

        [Comment(ApplicationUserIsActive)]
        public bool IsActive { get; set; } = true;
    }
}
