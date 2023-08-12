using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static PetHealthCenter.Common.Constants.AdminConstants;

namespace PetHealthCenter.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Route("Admin/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRolleName)]

    public class BaseController : Controller
    {
       
    }
}
