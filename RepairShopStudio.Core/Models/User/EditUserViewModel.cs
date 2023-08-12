using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Models.User;
using System.Diagnostics.CodeAnalysis;
using static RepairShopStudio.Common.Constants.ModelCommentConstants.User;

namespace RepairShopStudio.Core.Models.User
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
