using Microsoft.AspNetCore.Mvc;

namespace RepairShopStudio.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
