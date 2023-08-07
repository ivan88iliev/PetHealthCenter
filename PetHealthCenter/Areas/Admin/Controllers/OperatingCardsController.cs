using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.OperatingCard;
using System.Security.Claims;

namespace PetHealthCenter.Areas.Admin.Controllers
{
    public class OperatingCardsController : BaseController
    {
        private readonly IOperatingCardService operatingCardService;

        public OperatingCardsController(IOperatingCardService _operatingCardService)
        {
            operatingCardService = _operatingCardService;
        }

        /// <summary>
        /// Get all operating cards from Data-Base
        /// </summary>
        /// <returns>A list of operating cards</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await operatingCardService.GetAllAsync();

            return View(model);
        }

        /// <summary>
        /// Create new Operating card
        /// </summary>
        /// <param name="model"></param>
        /// <param name="customerId"></param>
        /// <returns>Add new operating card to Data-Base</returns>
        [HttpPost]
        public async Task<IActionResult> Add(OperatingCardAddViewModel model, int customerId)
        {

            try
            {
                await operatingCardService.AddOperatingCardAsync(model);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(model);
            }
        }

        /// <summary>
        /// Get all finished operating cards from Data-Base
        /// </summary>
        /// <returns>A list of operating cards with property IsActive == true</returns>
        [HttpGet]
        public async Task<IActionResult> AllFinished()
        {
            var model = await operatingCardService.GetAllFinishedAsync();

            return View(model);
        }
    }
}
