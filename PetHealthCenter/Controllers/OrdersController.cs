using Microsoft.AspNetCore.Mvc;

namespace PetHealthCenter.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
