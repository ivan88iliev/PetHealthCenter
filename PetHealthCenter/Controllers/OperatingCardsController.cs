using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Common.Constants;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.OperatingCard;
using System.Security.Claims;
using static PetHealthCenter.Common.Constants.RoleConstants;
using static PetHealthCenter.Common.Constants.ToastrMessagesConstatns;

namespace PetHealthCenter.Controllers
{
    [Authorize]
    public class OperatingCardsController : Controller
    {
        private readonly IOperatingCardService operatingCardService;

        public OperatingCardsController(
            IOperatingCardService _operatingCardService)
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

        [HttpPost]
        public async Task<IActionResult> Add(OperatingCardAddViewModel model, int customerId)
        {
            //TODO: Fix the Date in AddOperatingCard

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
                TempData[MessageConstant.SuccessMessage] = CreateOC;
                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = UnsuccessfulOperation;
                return View(model);
            }
        }

        /// <summary>
        /// Update opearting card status to "Completed"
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns>Add current operating card to collection "AllFinished"</returns>
        /// <exception cref="ArgumentException"></exception>
        [HttpGet]
        [Authorize(Roles = Doctor)]
        public async Task<IActionResult> Finish(int cardId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            try
            {
                await operatingCardService.MarkRepairAsFinishedAsync(cardId, userId);
                TempData[MessageConstant.WarningMessage] = CompleteCard;

            }
            catch (Exception)
            {
                TempData[MessageConstant.ErrorMessage] = NotAuthorized;
                return RedirectToAction(nameof(All));
            }

            return RedirectToAction(nameof(All));
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
