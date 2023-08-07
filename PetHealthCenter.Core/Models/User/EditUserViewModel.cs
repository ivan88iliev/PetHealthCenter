using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Infrastructure.Data.Models.User;
using System.Diagnostics.CodeAnalysis;
using static PetHealthCenter.Common.Constants.ModelCommentConstants.User;

namespace PetHealthCenter.Core.Models.User
{
    [Comment(EditViewModelMain)]
    public class EditUserViewModel
    {
        [Comment(EditViewModelUser)]
        public ApplicationUser User { get; set; } = null!;

        [Comment(EditViewModelRoles)]
        public IList<SelectListItem> Roles { get; set; } = null!;
    }
}
