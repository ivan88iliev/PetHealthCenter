using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Common.Constants;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.CustomerModels;
using RepairShopStudio.Core.Models.Vehicle;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Models.User;
using static RepairShopStudio.Common.Constants.RoleConstants;
using static RepairShopStudio.Common.Constants.ToastrMessagesConstatns;
using static RepairShopStudio.Common.Constants.LoggerMessageConstants;

namespace RepairShopStudio.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IVehicleService vehicleService;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public CustomersController(
            ICustomerService _customerService,
            ApplicationDbContext _context,
            RoleManager<ApplicationRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IVehicleService _vehicleService)

        {
            customerService = _customerService;
            context = _context;
            roleManager = _roleManager;
            userManager = _userManager;
            vehicleService = _vehicleService;
        }

        /// <summary>
        /// Get all customers from the Data-Base
        /// </summary>
        /// <returns>List of all customers</returns>
        [HttpGet]
        [Authorize(Roles = ServiceAdviser)]
        public async Task<IActionResult> All()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                TempData[MessageConstant.ErrorMessage] = NotAuthorized;
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var model = await customerService.GetAllAsync();

            return View(model);
        }

        /// <summary>
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
        [Authorize(Roles = ServiceAdviser)]
        public IActionResult AddRegular()
        {
            if (User.Identity.IsAuthenticated == false)
            {
                TempData[MessageConstant.ErrorMessage] = NotAuthorized;
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            var customerModel = new CustomerAddViewModel()
            {
                Vehicle = new VehicleAddViewModel()
                {
                    EngineTypes = context.EngineTypes.ToList()
                }
            };

            return View(customerModel);
        }

        /// <summary>
        /// Adding non-corporate customer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>New non-corporate customer in Data-Base</returns>
        [HttpPost]
        [Authorize(Roles = ServiceAdviser)]
        public async Task<IActionResult> AddRegular(CustomerAddViewModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                customerModel.Vehicle.EngineTypes = context.EngineTypes.ToList(); 
                TempData[MessageConstant.ErrorMessage] = InvalidData;
                return View(customerModel);
            }

            var vehicleLicense = customerModel.Vehicle.LicensePLate;
            if (vehicleLicense != null && await vehicleService.ExistsAsync(vehicleLicense))
            {
                TempData[MessageConstant.ErrorMessage] = VehicleAlreadyExists;
                return RedirectToAction("All", "Customers");
            }

            try
            {
                await customerService.AddRegularCutomerAsync(customerModel);
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = UnsuccessfulOperation;
                return View(customerModel);
            }
        }

        /// <summary>
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
        [Authorize(Roles = ServiceAdviser)]
        public IActionResult AddCorporate()
        {
            var customerModel = new CustomerAddViewModel()
            {
                Vehicle = new VehicleAddViewModel()
                {
                    EngineTypes = context.EngineTypes.ToList()
                }
            };

            return View(customerModel);
        }

        /// <summary>
        /// Adding corpoarte custommer
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>New corporate customer in Data-Base</returns>
        [HttpPost]
        [Authorize(Roles = ServiceAdviser)]
        public async Task<IActionResult> AddCorporate(CustomerAddViewModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                customerModel.Vehicle.EngineTypes = context.EngineTypes.ToList();
                TempData[MessageConstant.ErrorMessage] = InvalidData;
                return View(customerModel);
            }

            var vehicleLicense = customerModel.Vehicle.LicensePLate;
            if (vehicleLicense != null && await vehicleService.ExistsAsync(vehicleLicense))
            {
                TempData[MessageConstant.ErrorMessage] = VehicleAlreadyExists;
                return RedirectToAction("All", "Customers");
            }

            try
            {
                await customerService.AddCorporateCutomerAsync(customerModel);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");
                return View(customerModel);
            }
        }
    }
}
