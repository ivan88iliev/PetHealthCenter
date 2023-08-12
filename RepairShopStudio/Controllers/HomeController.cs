using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepairShopStudio.Common.Constants;
using RepairShopStudio.Models;
using System.Diagnostics;
using static RepairShopStudio.Common.Constants.AdminConstants;
using static RepairShopStudio.Common.Constants.ToastrMessagesConstatns;

namespace RepairShopStudio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> _logger)
        {
            logger = _logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Check if the current user is in Admin role
        /// </summary>
        /// <returns>Redirects to Admin aerea</returns>
        [Authorize(Roles = AdminRolleName)]
        public IActionResult ToAdminArea()
        {
            if (User.IsInRole(AdminRolleName))
            {
                TempData[MessageConstant.WarningMessage] = InvalidData;
                return RedirectToAction("Index", "Admin", new { area = "Admin" });
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var feature = this.HttpContext.Features.Get<IExceptionHandlerFeature>();

            logger.LogError(feature.Error, "TraceIdentifier: {0}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}