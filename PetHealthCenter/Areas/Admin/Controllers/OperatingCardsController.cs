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
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
        public async Task<IActionResult> Add(int customerId)
        {
            var model = new OperatingCardAddViewModel()
            {
                CustomerId = customerId,
                CustomerName = await operatingCardService.GetCustomerNameById(customerId),
                Pets = await operatingCardService.GetCustomerPets(customerId),
                ApplicationUsers = await operatingCardService.GetDoctorsAsync(),
                Parts = await operatingCardService.GetPartsAsync(),
                HealthServices = await operatingCardService.GetHealthServicesAsync(),
                IsActive = true
            };

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

            //if (!ModelState.IsValid)
            //{
            //    model.CustomerId = customerId;
            //    model.CustomerName = await operatingCardService.GetCustomerNameById(customerId);
            //    model.Pets = await operatingCardService.GetCustomerPets(customerId);
            //    model.ApplicationUsers = await operatingCardService.GetDoctorsAsync();
            //    model.Parts = await operatingCardService.GetPartsAsync();
            //    model.HealthServices = await operatingCardService.GetHealthServicesAsync();
            //    model.IsActive = true;

            //    return View(model);
            //}

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
