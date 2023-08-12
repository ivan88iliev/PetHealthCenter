using Microsoft.AspNetCore.Mvc;

namespace PetHealthCenter.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
