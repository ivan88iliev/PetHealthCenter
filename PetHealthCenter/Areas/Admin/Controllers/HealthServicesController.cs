using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Extensions;
using PetHealthCenter.Core.Models.HealthService;

namespace PetHealthCenter.Areas.Admin.Controllers
{
    public class HealthServicesController : BaseController
    {
        private readonly IHealthServiceService healthServiceService;

        public HealthServicesController(IHealthServiceService _healthServiceService)
        {
            healthServiceService = _healthServiceService;
        }

        /// <summary>
        /// Get all health services from Data-Base
        /// </summary>
        /// <returns>List of all health-services</returns>
        public async Task<IActionResult> All()
        {
            var model = await healthServiceService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddHealthServiceViewModel()
            {
                ProductComponents = await healthServiceService.GetProductComponentsAsync()
            };

            return View(model);
        }

        /// <summary>
        /// Add new health service to Data-Base
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Create new health service and add it to Data-Base</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddHealthServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await healthServiceService.AddAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        /// <summary>
        /// Check if a health service exists and takes it's details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details of a certain health service</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await healthServiceService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var service = await healthServiceService.ServiceDetailsById(id);
            var animalCompnentId = await healthServiceService.GetProductComponentId(id);

            var model = new HealthServiceViewModel()
            {
                Id = id,
                Name = service.Name,
                Price = service.Price,
                Description = service.Description,
                ProductComponentId = animalCompnentId,
                ProductComponents = await healthServiceService.AllProductComponents()
            };

            return View(model);
        }

        /// <summary>
        /// Update health service properties value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Update properties value of an already existing health service</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, HealthServiceViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await healthServiceService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Service component does not exist");
                model.ProductComponents = await healthServiceService.AllProductComponents();

                return View(model);
            }

            if ((await healthServiceService.ProductComponentExists(model.ProductComponentId)) == false)
            {
                ModelState.AddModelError(nameof(model.ProductComponentId), "Product component does not exist");
                model.ProductComponents = await healthServiceService.AllProductComponents();

                return View(model);
            }

            if (!ModelState.IsValid == false)
            {
                model.ProductComponents = await healthServiceService.AllProductComponents();

                return View(model);
            }

            await healthServiceService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetServiceInformation() });
        }

        /// <summary>
        /// Get details for a certain health service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns>Details for a certain health service from Data-Base</returns>
        public async Task<IActionResult> Details(int id, string information)
        {
            if ((await healthServiceService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await healthServiceService.ServiceDetailsById(id);

            if (information != model.GetServiceInformation())
            {
                TempData["ErrorMessage"] = "Don't touch my slug!";

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        /// <summary>
        /// Delete certain health service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Set IsActive property of a certain health service to false</returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            if ((await healthServiceService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            TempData["SuccessDeletePartMessage"] = "Service was deleted sucessfully";
            await healthServiceService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
