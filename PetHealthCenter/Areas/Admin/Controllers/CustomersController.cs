﻿using Microsoft.AspNetCore.Mvc;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.CustomerModels;
using PetHealthCenter.Core.Models.Pet;
using PetHealthCenter.Infrastructure.Data;

namespace PetHealthCenter.Areas.Admin.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomerService customerService;
        private readonly ApplicationDbContext context;

        public CustomersController(
            ICustomerService _customerService,
            ApplicationDbContext _context)
        {
            customerService = _customerService;
            context = _context;
        }

        /// <summary>
        /// Get all customers from Data-Base
        /// </summary>
        /// <returns>List of all customers</returns>
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await customerService.GetAllAsync();

            return View(model);
        }

        /// <summary>
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
        public IActionResult AddRegular()
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
        /// Add non-corporate customer to Data-Base
        /// </summary>
        /// <returns>Add customer without Address, Uic and Responsible person properties</returns>
        [HttpPost]
        public async Task<IActionResult> AddRegular(CustomerAddViewModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                customerModel.Pet.SpecieTypes = context.SpecieTypes.ToList();
                return View(customerModel);
            }

            try
            {
                await customerService.AddRegularCutomerAsync(customerModel);

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong...");

                return View(customerModel);
            }
        }

        /// <summary>
        /// Get information for properties with more than one value
        /// </summary>
        /// <returns>A view with information with information already loaded in it</returns>
        [HttpGet]
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
        /// Add corporate customer to Data-Base
        /// </summary>
        /// <returns>Add customer with Address, Uic and Responsible person properties</returns>
        [HttpPost]
        public async Task<IActionResult> AddCorporate(CustomerAddViewModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                customerModel.Pet.SpecieTypes = context.SpecieTypes.ToList();
                return View(customerModel);
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
