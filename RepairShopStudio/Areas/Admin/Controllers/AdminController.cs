using Microsoft.AspNetCore.Mvc;

namespace RepairShopStudio.Areas.Admin.Controllers
{
    public class AdminController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
