using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Extensions;
using PetHealthCenter.Core.Models.Part;
using PetHealthCenter.Infrastructure.Data;

namespace PetHealthCenter.Areas.Admin.Controllers
{
    public class PartsController : BaseController
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
        public async Task<IActionResult> All([FromQuery] PartsQueryModel query)
        {
            var result = await partService.AllAsync(
                query.SearchTerm,
                query.Manufacturer,
                query.ProductComponent,
                query.Sorting,
                query.CurrentPage,
                PartsQueryModel.PartsPerPage);

            query.TotalPartsCount = result.TotalPartsCount;
            query.ProductComponents = await partService.AllProductComponentsNames();
            query.Manufacturers = await partService.AllManufacturers();
            query.Parts = result.Parts;

            return View(query);
        }

        /// <summary>
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddPartViewModel()
            {
                ProductComponents = await partService.GetProductComponentsAsync()
            };

            return View(model);
        }

        /// <summary>
        /// Create new part
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Add new part to Data-Base</returns>
        [HttpPost]
        public async Task<IActionResult> Add(AddPartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await partService.AddPartAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        /// <summary>
        /// Check if a part exists and takes it's details
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Details of a certain part</returns>
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var part = await partService.PartDetailsById(id);
            var animalCompnentId = await partService.GetProductComponentId(id);

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
                ProductComponentId = animalCompnentId,
                ProductComponents = await partService.AllProductComponents()
            };

            return View(model);
        }

        /// <summary>
        /// Update part properties value
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns>Update properties value of an already existing part</returns>
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PartViewModel model)
        {
            if (id != model.Id)
            {
                return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
            }

            if ((await partService.Exists(model.Id)) == false)
            {
                ModelState.AddModelError("", "House does not exist");
                model.ProductComponents = await partService.AllProductComponents();
                return View(model);
            }

            if ((await partService.ProductComponentExists(model.ProductComponentId)) == false)
            {
                ModelState.AddModelError(nameof(model.ProductComponentId), "Category does not exist");
                model.ProductComponents = await partService.AllProductComponents();

                return View(model);
            }

            if (!ModelState.IsValid == false)
            {
                model.ProductComponents = await partService.AllProductComponents();

                return View(model);
            }

            await partService.Edit(model.Id, model);

            return RedirectToAction(nameof(Details), new { id = model.Id, information = model.GetPartInformation() });
        }

        /// <summary>
        /// Get details for a certain part
        /// </summary>
        /// <param name="id"></param>
        /// <param name="information"></param>
        /// <returns>Details for a certain part from Data-Base</returns>
        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            var model = await partService.PartDetailsById(id);

            if (information != model.GetPartInformation())
            {
                TempData["ErrorMessage"] = "Don't touch my slug!";

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        /// <summary>
        /// Delete certain part
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Set IsActive property of a certain part to false</returns>
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            if ((await partService.Exists(id)) == false)
            {
                return RedirectToAction(nameof(All));
            }

            TempData["SuccessDeletePartMessage"] = "Part was deleted sucessfully";
            await partService.Delete(id);

            return RedirectToAction(nameof(All));
        }
    }
}
