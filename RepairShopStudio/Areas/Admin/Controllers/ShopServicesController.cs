using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Extensions;
using RepairShopStudio.Core.Models.ShopService;

namespace RepairShopStudio.Areas.Admin.Controllers
{
    public class ShopServicesController : BaseController
    {
        private readonly IShopServiceService shopServiceService;

        public ShopServicesController(IShopServiceService _shopServiceService)
        {
            shopServiceService = _shopServiceService;
        }

        /// <summary>
        /// Get all shop services from Data-Base
        /// </summary>
        /// <returns>List of all shop-services</returns>
        public async Task<IActionResult> All()
        {
            var model = await shopServiceService.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddShopServiceViewModel()
            {
                VehicleComponents = await shopServiceService.GetVehicleComponentsAsync()
            };

            return View(model);
        }

        /// <summary>
        /// Add new shop service to Data-Base
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Create new shop service and add it to Data-Base</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddShopServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await shopServiceService.AddAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        /// <summary>
        /// Check if a shop service exists and takes it's details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details of a certain shop service</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await shopServiceService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var service = await shopServiceService.ServiceDetailsById(id);
            var vehicleCompnentId = await shopServiceService.GetVehicleComponentId(id);

            var model = new ShopServiceViewModel()
            {
                Id = id,
                Name = service.Name,
                Price = service.Price,
                Description = service.Description,
                VehicleComponentId = vehicleCompnentId,
                VehicleComponents = await shopServiceService.AllVehicleComponents()
            };

            return View(model);
        }

        /// <summary>
        /// Update shop service properties value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Update properties value of an already existing shop service</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, ShopServiceViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await shopServiceService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "Service component does not exist");
                model.VehicleComponents = await shopServiceService.AllVehicleComponents();

                return View(model);
            }

            if ((await shopServiceService.VehicleComponentExists(model.VehicleComponentId)) == false)
            {
                ModelState.AddModelError(nameof(model.VehicleComponentId), "Vehicle component does not exist");
                model.VehicleComponents = await shopServiceService.AllVehicleComponents();

                return View(model);
            }

            if (!ModelState.IsValid == false)
            {
                model.VehicleComponents = await shopServiceService.AllVehicleComponents();

                return View(model);
            }

            await shopServiceService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetServiceInformation() });
        }

        /// <summary>
        /// Get details for a certain shop service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns>Details for a certain shop service from Data-Base</returns>
        public async Task<IActionResult> Details(int id, string information)
        {
            if ((await shopServiceService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await shopServiceService.ServiceDetailsById(id);

            if (information != model.GetServiceInformation())
            {
                TempData["ErrorMessage"] = "Don't touch my slug!";

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        /// <summary>
        /// Delete certain shop service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Set IsActive property of a certain shop service to false</returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            if ((await shopServiceService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            TempData["SuccessDeletePartMessage"] = "Service was deleted sucessfully";
            await shopServiceService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
