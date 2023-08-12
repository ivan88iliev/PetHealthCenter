using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Core.Contracts;
using static RepairShopStudio.Common.Constants.ExceptionMessagesConstants;

namespace RepairShopStudio.Controllers
{
    [Authorize]
    public class ShopServicesController : Controller
    {
        private readonly IShopServiceService shopServiceService;

        public ShopServicesController(IShopServiceService _shopServiceService)
        {
            shopServiceService = _shopServiceService;
        }

        /// <summary>
        /// Get all Shop services from the Data-Base
        /// </summary>
        /// <returns>A list of all shop services</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await shopServiceService.GetAllAsync();

            if (model == null)
            {
                throw new InvalidOperationException(InvalidGetShopServicesException);
            }

            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    var model = new AddShopServiceViewModel()
        //    {
        //        VehicleComponents = await shopServiceService.GetVehicleComponentsAsync()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(AddShopServiceViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    try
        //    {
        //        await shopServiceService.AddAsync(model);

        //        return RedirectToAction(nameof(All));
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "Something went wrong...");

        //        return View(model);
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    if ((await shopServiceService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    var service = await shopServiceService.ServiceDetailsById(id);
        //    var vehicleCompnentId = await shopServiceService.GetVehicleComponentId(id);

        //    var model = new ShopServiceViewModel()
        //    {
        //        Id = id,
        //        Name = service.Name,
        //        Price = service.Price,
        //        Description = service.Description,
        //        VehicleComponentId = vehicleCompnentId,
        //        VehicleComponents = await shopServiceService.AllVehicleComponents()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, ShopServiceViewModel model)
        //{
        //    if (id != model.Id)
        //    {
        //        return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
        //    }

        //    if ((await shopServiceService.Exists(model.Id)) == false)
        //    {
        //        ModelState.AddModelError("", "House does not exist");
        //        model.VehicleComponents = await shopServiceService.AllVehicleComponents();

        //        return View(model);
        //    }

        //    if ((await shopServiceService.VehicleComponentExists(model.VehicleComponentId)) == false)
        //    {
        //        ModelState.AddModelError(nameof(model.VehicleComponentId), "Category does not exist");
        //        model.VehicleComponents = await shopServiceService.AllVehicleComponents();

        //        return View(model);
        //    }

        //    if (!ModelState.IsValid == false)
        //    {
        //        model.VehicleComponents = await shopServiceService.AllVehicleComponents();

        //        return View(model);
        //    }

        //    await shopServiceService.Edit(model.Id, model);

        //    return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetServiceInformation() });
        //}

        //public async Task<IActionResult> Details(int id, string information)
        //{
        //    if ((await shopServiceService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    var model = await shopServiceService.ServiceDetailsById(id);

        //    if (information != model.GetServiceInformation())
        //    {
        //        TempData["ErrorMessage"] = "Don't touch my slug!";

        //        return RedirectToAction("Index", "Home");
        //    }

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Delete([FromForm] int id)
        //{
        //    if ((await shopServiceService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    TempData["SuccessDeletePartMessage"] = "Service was deleted sucessfully";
        //    await shopServiceService.Delete(id);

        //    return RedirectToAction(nameof(All));
        //}
    }
}
