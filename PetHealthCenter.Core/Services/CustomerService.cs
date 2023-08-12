using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.CustomerModels;
using PetHealthCenter.Core.Models.SpecieType;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Common;
using static PetHealthCenter.Common.Constants.ExceptionMessagesConstants;
using static PetHealthCenter.Common.Constants.LoggerMessageConstants;
using Address = PetHealthCenter.Infrastructure.Data.Models.Address;
using Customer = PetHealthCenter.Infrastructure.Data.Models.Customer;
using SpecieType = PetHealthCenter.Infrastructure.Data.Models.SpecieType;
using Pet = PetHealthCenter.Infrastructure.Data.Models.Pet;

namespace PetHealthCenter.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;
        private readonly IRepository repo;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(
            ApplicationDbContext _context,
            IRepository _repo,
            ILogger<CustomerService> _logger)
        {
            context = _context;
            repo = _repo;
            logger = _logger;
        }

        /// <summary>
        /// Add new user, animal and address to Data-Base
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>Create new customer with it's animal and Address</returns>
        public async Task AddCorporateCutomerAsync(CustomerAddViewModel customerModel)
        {
            var address = new Address()
            {
                Id = customerModel.Address.Id,
                AddressText = customerModel.Address.AddressText,
                ZipCode = customerModel.Address.ZipCode,
                TownName = customerModel.Address.TownName
            };

            if (address == null)
            {
                logger.LogError(NullAddres);
                throw new NullReferenceException(InvalidAddressException);
            }

            await context.AddAsync<Address>(address);
            await context.SaveChangesAsync();

            var customer = new Customer()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Email = customerModel.Email,
                PhoneNumber = customerModel.PhoneNumber,
                IsCorporate = true,
                ResponsiblePerson = customerModel.ResponsiblePerson,
                Uic = customerModel.Uic,
                AddressId = address.Id
            };

            if (customer == null)
            {
                logger.LogError(NullCustomer);
                throw new NullReferenceException(InvalidCustomerException);
            }

            await context.AddAsync<Customer>(customer);
            await context.SaveChangesAsync();

            var animal = new Pet()
            {
                Id = customerModel.Pet.Id,
                Make = customerModel.Pet.Make,
                Model = customerModel.Pet.Model,
                VinNumber = customerModel.Pet.VinNumber,
                Power = customerModel.Pet.Power,
                SpecieTypeId = customerModel.Pet.SpecieTypeId,
                IdentificationNUmber = customerModel.Pet.IdentificationNUmber,
                FIrstRegistration = customerModel.Pet.FIrstRegistration,
                CustomerId = customer.Id
            };

            if (animal == null)
            {
                logger.LogError(NullPet);
                throw new InvalidOperationException(InvalidPetException);
            }

            await context.AddAsync<Pet>(animal);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Add new user and animal to Data-Base
        /// </summary>
        /// <param name="customerModel"></param>
        /// <returns>Create new customer (without Uic and Responsible person) and Pet</returns>
        public async Task AddRegularCutomerAsync(CustomerAddViewModel customerModel)
        {
            var customer = new Customer()
            {
                Id = customerModel.Id,
                Name = customerModel.Name,
                Email = customerModel.Email,
                PhoneNumber = customerModel.PhoneNumber,
                IsCorporate = false,
            };

            if (customer == null)
            {
                logger.LogError(NullCustomer);
                throw new InvalidOperationException(InvalidCustomerException);
            }

            await context.AddAsync<Customer>(customer);
            await context.SaveChangesAsync();

            var animal = new Pet()
            {
                Id = customerModel.Pet.Id,
                Make = customerModel.Pet.Make,
                Model = customerModel.Pet.Model,
                VinNumber = customerModel.Pet.VinNumber,
                Power = customerModel.Pet.Power,
                SpecieTypeId = customerModel.Pet.SpecieTypeId,
                IdentificationNUmber = customerModel.Pet.IdentificationNUmber,
                FIrstRegistration = customerModel.Pet.FIrstRegistration,
                CustomerId = customer.Id
            };

            if (animal == null)
            {
                logger.LogError(NullPet);
                throw new InvalidOperationException(InvalidPetException);
            }

            await context.AddAsync<Pet>(animal);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Get all specie types
        /// </summary>
        /// <returns>List of EngyneTypesViewModel for all specie types</returns>
        public async Task<IEnumerable<SpecieTypeViewModel>> AllSpecieTypesAsync()
        {
            return await repo.AllReadonly<SpecieType>()
                .Select(c => new SpecieTypeViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }


        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all customers</returns>
        public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
        {
            var entities = await context.Customers
                .Include(c => c.Address)
                .Include(c => c.Pets)
                .OrderByDescending(c => c.IsCorporate)
                .ThenBy(c => c.Name)
                .ToListAsync();

            if (entities == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new NullReferenceException(InvalidGetAllException);
            }

            return entities
                .Select(p => new CustomerViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    IsCorporate = p.IsCorporate,
                    Pets = p.Pets,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Address = $"{p.Address?.ZipCode}, {p.Address?.AddressText}, {p.Address?.TownName}",
                    ResponsiblePerson = p.ResponsiblePerson,
                    Uic = p.Uic
                });
        }

        /// <summary>
        /// Get all specie types
        /// </summary>
        /// <returns>List of all specie types</returns>
        public async Task<IEnumerable<SpecieType>> GetSpecieTypesAsync()
        {
            var result = await context.SpecieTypes.ToListAsync();

            if (result == null)
            {
                logger.LogError(GetDataUnsuccessfull);
                throw new NullReferenceException(InvalidGetSpecieTypeException);
            }

            return result;
        }

    }
}
