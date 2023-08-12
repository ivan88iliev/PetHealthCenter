using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.OperatingCard;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Models;
using PetHealthCenter.Infrastructure.Data.Models.User;
using static PetHealthCenter.Common.Constants.ExceptionMessagesConstants;
using static PetHealthCenter.Common.Constants.LoggerMessageConstants;

namespace PetHealthCenter.Core.Services
{
    public class OperatingCardService : IOperatingCardService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly ILogger<OperatingCardService> logger;

        public OperatingCardService(
            ApplicationDbContext _context,
            IRepository _repo,
            ILogger<OperatingCardService> _logger)
        {
            context = _context;
            repo = _repo;
            logger = _logger;
        }

        /// <summary>
        /// Create new operating card
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Add new operating card to Data-Base</returns>
        public async Task AddOperatingCardAsync(OperatingCardAddViewModel model)
        {
            var entity = new OperatingCard()
            {
                Id = model.Id,
                ApplicationUserId = Guid.Parse(model.ApplicationUserId),
                CustomerId = model.CustomerId,
                Date = DateTime.Today,
                PetId = model.PetId,
                IsActive = true,
                PartId = model.PartId,
                ServiceId = model.ServiceId
            };

            if (entity == null)
            {
                logger.LogError(NullOperatingCard);
                throw new InvalidOperationException(InvalidOperatingCardException);
            }

            entity.DocumentNumber 
                = $"{context.Pets.FirstOrDefault(v => v.Id == entity.PetId).IdentificationNUmber}/{entity.Date.ToString("dd.MM.yyyy")}";

            
            await context.OperatingCards.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all operating cards from Data-Base
        /// </summary>
        /// <returns>List of all operating cards</returns>
        public async Task<IEnumerable<OperatingCardViewModel>> GetAllAsync()
        {
            var entities = await context.OperatingCards
                .Where(oc => oc.IsActive == true)
                .Include(c => c.Customer)
                .Include(p => p.Part)
                .Include(s => s.Service)
                .Include(cv => cv.Customer.Pets)
                .Include(au => au.ApplicationUser)
                .ToListAsync();

            if (entities == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetAllOperatingCardsException);
            }

            return entities
                .Select(oc => new OperatingCardViewModel
                {
                    Id = oc.Id,
                    CustomerName = oc.Customer.Name,
                    DoctorName = $"{oc.ApplicationUser.FirstName} {oc.ApplicationUser.LastName}",
                    PartName = oc.Part.Name,
                    ServiceName = oc.Service.Name,
                    IsActive = oc.IsActive,
                    IssueDate = oc.Date.ToString("dd.MM.yyyy"),
                    PetIdentificationNumber = oc.Customer.Pets.FirstOrDefault(v => v.Id == oc.PetId).IdentificationNUmber,
                    DocumentNumber = oc.DocumentNumber,
                });
        }

        /// <summary>
        /// Get all operating cards with property IsActive == false from Data-Base
        /// </summary>
        /// <returns>List of all completed operating cards</returns>
        public async Task<IEnumerable<OperatingCardViewModel>> GetAllFinishedAsync()
        {
            var entities = await context.OperatingCards
                .Where(oc => oc.IsActive == false)
                .Include(c => c.Customer)
                .Include(p => p.Part)
                .Include(s => s.Service)
                .Include(cv => cv.Customer.Pets)
                .Include(au => au.ApplicationUser)
                .ToListAsync();

            if (entities == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetAllFinishedOperatingCardsException);
            }

            return entities
                .Select(oc => new OperatingCardViewModel
                {
                    Id = oc.Id,
                    CustomerName = oc.Customer.Name,
                    DoctorName = $"{oc.ApplicationUser.FirstName} {oc.ApplicationUser.LastName}",
                    PartName = oc.Part.Name,
                    ServiceName = oc.Service.Name,
                    IsActive = oc.IsActive,
                    IssueDate = oc.Date.ToString("dd.MM.yyyy"),
                    PetIdentificationNumber = oc.Customer.Pets.FirstOrDefault(v => v.Id == oc.PetId).IdentificationNUmber,
                    DocumentNumber = oc.DocumentNumber,
                });
        }

        /// <summary>
        /// Get a customer with a certain Id from Data-Base
        /// </summary>
        /// <param name="cutomerId"></param>
        /// <returns>Customer</returns>
        public async Task<string> GetCustomerNameById(int cutomerId)
        {
            var customer = context.Customers
                .Where(c => c.Id == cutomerId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();

            if (customer == null)
            {
                logger.LogError(NullCustomer);
                throw new NullReferenceException(InvalidCustomerIdException);
            }

            return await customer;
        }

        /// <summary>
        /// Get all customers from Data-Base
        /// </summary>
        /// <returns>A list of all customers</returns>
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            var result = await context.Customers.ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetCustomersException);
            }

            return result;
        }

        /// <summary>
        /// Get animals of a certain customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>List of animals owned by a certain customer</returns>
        public async Task<IEnumerable<Pet>> GetCustomerPets(int customerId)
        {
            var result = await context.Pets.Where(v => v.CustomerId == customerId).ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetCustomerPetsException);
            }

            return result;
        }

        /// <summary>
        /// Get all users in role "Doctor"
        /// </summary>
        /// <returns>List of all users in role "Doctor"</returns>
        public async Task<IEnumerable<ApplicationUser>> GetDoctorsAsync()
        {
            var result = await context.Users.Where(u => u.UserName.ToLower().Contains("doctor")).ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetDoctorsException);
            }

            return result;
        }

        /// <summary>
        /// Get all parts from Data-Base
        /// </summary>
        /// <returns>List of all parts</returns>
        public async Task<IEnumerable<Part>> GetPartsAsync()
        {
            var result = await context.Parts.ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetPartsException);
            }

            return result;
        }

        /// <summary>
        /// Get all health services from Data-Base
        /// </summary>
        /// <returns>List of all health services</returns>
        public async Task<IEnumerable<HealthService>> GetHealthServicesAsync()
        {
            var result = await context.HealthServices.ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new InvalidOperationException(InvalidGetHealthServicesException);
            }

            return result;
        }

        /// <summary>
        /// Check if the curren user is the same as the doctor with assigned certain operating card, set the card's status to complete and removes 1ps of the part from the Data-Base
        /// </summary>
        /// <param name="cardId"></param>
        /// <param name="userId"></param>
        /// <returns>Set the operating card's status to Complete and update part's stock</returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task MarkRepairAsFinishedAsync(int cardId, string userId)
        {
            var user = await context.Users
               .Where(u => u.Id == Guid.Parse(userId))
               .FirstOrDefaultAsync();

            if (user == null)
            {
                logger.LogError(NullUser);
                throw new ArgumentException(InvalidUserIdExceptionMessage);
            }

            var card = await context.OperatingCards.FirstOrDefaultAsync(m => m.Id == cardId);

            if (card == null)
            {
                logger.LogError(NullOperatingCard);
                throw new ArgumentException(InvalidCardIdExceptionMessage);
            }

            if (card != null && card.ApplicationUserId == Guid.Parse(userId))
            {
                card.IsActive = false;
            }
            else
            {
                logger.LogError(NullOperatingCard);
                throw new ArgumentException(UnauthorizedActionException);
            }

            var part = await context.Parts.FirstOrDefaultAsync(p => p.Id == card.PartId);
            if (part != null)
            {
                part.Stock -= 1;
            }
            else
            {
                logger.LogError(NullPart);
                throw new ArgumentException(PartDoesNotExistExceptionMessage);
            }

            await context.SaveChangesAsync();
        }
    }
}
