using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Common.Constants;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.CustomerModels;
using PetHealthCenter.Core.Models.Pet;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Models.User;
using static PetHealthCenter.Common.Constants.RoleConstants;
using static PetHealthCenter.Common.Constants.ToastrMessagesConstatns;
using static PetHealthCenter.Common.Constants.LoggerMessageConstants;

namespace PetHealthCenter.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly IPetService animalService;
        private readonly ApplicationDbContext context;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public CustomersController(
            ICustomerService _customerService,
            ApplicationDbContext _context,
            RoleManager<ApplicationRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IPetService _animalService)

        {
            customerService = _customerService;
            context = _context;
            roleManager = _roleManager;
            userManager = _userManager;
            animalService = _animalService;
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
                Pet = new PetAddViewModel()
                {
                    SpecieTypes = context.SpecieTypes.ToList()
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
                customerModel.Pet.SpecieTypes = context.SpecieTypes.ToList(); 
                TempData[MessageConstant.ErrorMessage] = InvalidData;
                return View(customerModel);
            }

            var animalLicense = customerModel.Pet.IdentificationNUmber;
            if (animalLicense != null && await animalService.ExistsAsync(animalLicense))
            {
                TempData[MessageConstant.ErrorMessage] = PetAlreadyExists;
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
                Pet = new PetAddViewModel()
                {
                    SpecieTypes = context.SpecieTypes.ToList()
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
                customerModel.Pet.SpecieTypes = context.SpecieTypes.ToList();
                TempData[MessageConstant.ErrorMessage] = InvalidData;
                return View(customerModel);
            }

            var animalLicense = customerModel.Pet.IdentificationNUmber;
            if (animalLicense != null && await animalService.ExistsAsync(animalLicense))
            {
                TempData[MessageConstant.ErrorMessage] = PetAlreadyExists;
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
