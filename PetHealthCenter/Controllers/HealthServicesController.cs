using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Core.Contracts;
using static PetHealthCenter.Common.Constants.ExceptionMessagesConstants;

namespace PetHealthCenter.Controllers
{
    [Authorize]
    public class HealthServicesController : Controller
    {
        private readonly IHealthServiceService healthServiceService;

        public HealthServicesController(IHealthServiceService _healthServiceService)
        {
            healthServiceService = _healthServiceService;
        }

        /// <summary>
        /// Get all Health services from the Data-Base
        /// </summary>
        /// <returns>A list of all health services</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await healthServiceService.GetAllAsync();

            if (model == null)
            {
                throw new InvalidOperationException(InvalidGetHealthServicesException);
            }

            return View(model);
        }

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    var model = new AddHealthServiceViewModel()
        //    {
        //        ProductComponents = await healthServiceService.GetProductComponentsAsync()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(AddHealthServiceViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    try
        //    {
        //        await healthServiceService.AddAsync(model);

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
        //    if ((await healthServiceService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    var service = await healthServiceService.ServiceDetailsById(id);
        //    var animalCompnentId = await healthServiceService.GetProductComponentId(id);

        //    var model = new HealthServiceViewModel()
        //    {
        //        Id = id,
        //        Name = service.Name,
        //        Price = service.Price,
        //        Description = service.Description,
        //        ProductComponentId = animalCompnentId,
        //        ProductComponents = await healthServiceService.AllProductComponents()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, HealthServiceViewModel model)
        //{
        //    if (id != model.Id)
        //    {
        //        return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
        //    }

        //    if ((await healthServiceService.Exists(model.Id)) == false)
        //    {
        //        ModelState.AddModelError("", "House does not exist");
        //        model.ProductComponents = await healthServiceService.AllProductComponents();

        //        return View(model);
        //    }

        //    if ((await healthServiceService.ProductComponentExists(model.ProductComponentId)) == false)
        //    {
        //        ModelState.AddModelError(nameof(model.ProductComponentId), "Category does not exist");
        //        model.ProductComponents = await healthServiceService.AllProductComponents();

        //        return View(model);
        //    }

        //    if (!ModelState.IsValid == false)
        //    {
        //        model.ProductComponents = await healthServiceService.AllProductComponents();

        //        return View(model);
        //    }

        //    await healthServiceService.Edit(model.Id, model);

        //    return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetServiceInformation() });
        //}

        //public async Task<IActionResult> Details(int id, string information)
        //{
        //    if ((await healthServiceService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    var model = await healthServiceService.ServiceDetailsById(id);

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
        //    if ((await healthServiceService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    TempData["SuccessDeletePartMessage"] = "Service was deleted sucessfully";
        //    await healthServiceService.Delete(id);

        //    return RedirectToAction(nameof(All));
        //}
    }
}
