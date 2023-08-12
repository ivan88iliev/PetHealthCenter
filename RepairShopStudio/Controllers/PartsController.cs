using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepairShopStudio.Common.Constants;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Extensions;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Infrastructure.Data;
using static RepairShopStudio.Common.Constants.ToastrMessagesConstatns;

namespace RepairShopStudio.Controllers
{
    [Authorize]
    public class PartsController : Controller
    {
        private readonly IPartService partService;
        private readonly ApplicationDbContext context;

        public PartsController(IPartService _partService,
            ApplicationDbContext _context)
        {
            partService = _partService;
            context = _context;
        }

        /// <summary>
        /// Get all parts from Data-Base
        /// </summary>
        /// <returns>A list of all parts</returns>
        [HttpGet]
        public async Task<IActionResult> All([FromQuery]PartsQueryModel query)
        {
            var result = await partService.AllAsync(
                query.SearchTerm,
                query.Manufacturer,
                query.VehicleComponent,
                query.Sorting,
                query.CurrentPage,
                PartsQueryModel.PartsPerPage);

            query.TotalPartsCount = result.TotalPartsCount;
            query.VehicleComponents = await partService.AllVehicleComponentsNames();
            query.Manufacturers = await partService.AllManufacturers();
            query.Parts = result.Parts;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddPartViewModel()
            {
                VehicleComponents = await partService.GetVehicleComponentsAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = InvalidData;
                return View(model);
            }

            try
            {
                await partService.AddPartAsync(model);
                TempData[MessageConstant.SuccessMessage] = CreatePart;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = UnsuccessfulOperation;
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await partService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = UnexistingPart;
                return RedirectToAction(nameof(All));
            }

            var part = await partService.PartDetailsById(id);
            var vehicleCompnentId = await partService.GetVehicleComponentId(id);

            var model = new PartViewModel()
            {
                Id = id,
                Name = part.Name,
                PriceBuy = part.PriceBuy,
                PriceSell = part.PriceSell,
                Description = part.Description,
                Manufacturer = part.Manufacturer,
                OriginalMpn = part.OriginalMpn,
                ImageUrl = part.ImageUrl,
                Stock = part.Stock,
                VehicleComponentId = vehicleCompnentId,
                VehicleComponents = await partService.AllVehicleComponents()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PartViewModel model)
        {
            if (id != model.Id)
            {
                TempData[MessageConstant.ErrorMessage] = UnsuccessfulOperation;
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await partService.Exists(model.Id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = UnexistingPart;
                model.VehicleComponents = await partService.AllVehicleComponents();

                return View(model);
            }

            if ((await partService.VehicleComponentExists(model.VehicleComponentId)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = UnexistingComponent;
                model.VehicleComponents = await partService.AllVehicleComponents();

                return View(model);
            }

            if (!ModelState.IsValid == false)
            {
                TempData[MessageConstant.ErrorMessage] = UnsuccessfulOperation;
                model.VehicleComponents = await partService.AllVehicleComponents();
                return View(model);
            }

            await partService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetPartInformation() });
        }

        public async Task<IActionResult> Details(int id, string information)
        {
            if ((await partService.Exists(id)) == false)
            {
                TempData[MessageConstant.ErrorMessage] = UnexistingPart;
                return RedirectToAction(nameof(All));
            }

            var model = await partService.PartDetailsById(id);

            if (information != model.GetPartInformation())
            {
                TempData[MessageConstant.ErrorMessage] = NotAuthorized;
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> Delete([FromForm] int id)
        //{
        //    if ((await partService.Exists(id)) == false)
        //    {
        //        return RedirectToAction(nameof(All));
        //    }

        //    TempData["SuccessDeletePartMessage"] = "Part was deleted sucessfully";
        //    await partService.Delete(id);

        //    return RedirectToAction(nameof(All));
        //}
    }
}
