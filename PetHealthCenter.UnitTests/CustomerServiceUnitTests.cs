using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.Address;
using PetHealthCenter.Core.Models.CustomerModels;
using PetHealthCenter.Core.Models.SpecieType;
using PetHealthCenter.Core.Models.Pet;
using PetHealthCenter.Core.Services;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.UnitTests
{
    [TestFixture]
    public class CustomerServiceUnitTests
    {
        private IRepository repo;
        private ILogger<CustomerService> logger;
        private ICustomerService customerService;
        private ApplicationDbContext applicationDbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("PetHealthDB")
                .Options;

            applicationDbContext = new ApplicationDbContext(contextOptions);

            applicationDbContext.Database.EnsureDeleted();
            applicationDbContext.Database.EnsureCreated();
        }

        [Test]
        public async Task TestAddCorporateCutomerAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            var customerModel = new CustomerAddViewModel()
            {
                Id = 100,
                Name = "Test Test",
                Email = "test@mail.bg",
                PhoneNumber = "+35900000000",
                IsCorporate = true,
                ResponsiblePerson = "Test Test",
                Uic = "111111111",
                Address = new AddressAddViewModel()
                {
                    Id = 100,
                    ZipCode = "1111",
                    TownName = "Test City",
                    AddressText = "Test str."
                },
                Pet = new PetAddViewModel()
                {
                    Id = 100,
                    Make = "Test",
                    Model = "Test",
                    PetNumber = "1111111111111",
                    Weight = 100,
                    SpecieTypeId = 1,
                    IdentificationNUmber = "B3333BB",
                    FIrstRegistration = DateTime.Today
                }
            };

            await customerService.AddCorporateCutomerAsync(customerModel);

            Assert.That(applicationDbContext.Addresses.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Pets.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.Any(c => c.AddressId == customerModel.Address.Id), Is.True);

            Assert.That(applicationDbContext.Customers.FirstOrDefault(c => c.Id == customerModel.Id)?.Pets
                .Any(v => v.Id == customerModel.Pet.Id), Is.True);

        }

        [Test]
        public async Task TestAddCorporateCustomerInMemoryCatchExceptionNullAddress()
        {
            var customerModelEx = new CustomerAddViewModel()
            {
                Id = 110,
                Name = "Test Test",
                Email = "test@mail.bg",
                PhoneNumber = "+35900000000",
                IsCorporate = true,
                ResponsiblePerson = "Test Test",
                Uic = "111111111",
                Pet = new PetAddViewModel()
                {
                    Id = 110,
                    Make = "Test",
                    Model = "Test",
                    PetNumber = "1111111111111",
                    Weight = 100,
                    SpecieTypeId = 1,
                    IdentificationNUmber = "B3333BB",
                    FIrstRegistration = DateTime.Today
                }
            };

            Assert.Throws<NullReferenceException>(() => customerService.AddCorporateCutomerAsync(customerModelEx), 
                "Something went wrong while creating the address!");
        }

        [Test]
        public async Task TesAddCorporateCustomrInMemoryCatchExceptionNullCustomer()
        {
            CustomerAddViewModel customerModelEx = null;

            Assert.Throws<NullReferenceException>(() => customerService.AddCorporateCutomerAsync(customerModelEx),
                "Something went wrong while creating the customer!");
        }

        [Test]
        public async Task TestAddRegularCutomerAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            var customerModel = new CustomerAddViewModel()
            {
                Id = 100,
                Name = "Test Test",
                Email = "test@mail.bg",
                PhoneNumber = "+35900000000",
                IsCorporate = true,
                ResponsiblePerson = "Test Test",
                Uic = "111111111",
                Pet = new PetAddViewModel()
                {
                    Id = 100,
                    Make = "Test",
                    Model = "Test",
                    PetNumber = "1111111111111",
                    Weight = 100,
                    SpecieTypeId = 1,
                    IdentificationNUmber = "B3333BB",
                    FIrstRegistration = DateTime.Today
                }
            };

            await customerService.AddRegularCutomerAsync(customerModel);

            Assert.That(applicationDbContext.Customers.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Pets.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.FirstOrDefault(c => c.Id == customerModel.Id)?.Pets
                .Any(v => v.Id == customerModel.Pet.Id), Is.True);


            var customerModelEx = new CustomerAddViewModel()
            {
                Id = 110,
                Name = "Test Test",
                Email = "test@mail.bg",
                PhoneNumber = "+35900000000",
                IsCorporate = true,
                ResponsiblePerson = "Test Test",
                Uic = "111111111",
                Pet = null
            };

            try
            {
                await customerService.AddCorporateCutomerAsync(customerModelEx);
                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is NullReferenceException);
            }
        }

        [Test]
        public async Task TestAllSpecieTypesAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<SpecieType>()
            {
                new SpecieType() { Id = 100, Name = "" },
                new SpecieType() { Id = 103, Name = "" },
                new SpecieType() { Id = 105, Name = "" },
                new SpecieType() { Id = 102, Name = "" }
            });

            await repo.SaveChangesAsync();
            IEnumerable<SpecieTypeViewModel> collection = await customerService.AllSpecieTypesAsync();

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(4, Is.EqualTo(collection.Count(c => c.Id >= 100)));
        }

        [Test]
        public async Task TestGetAllAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<Customer>()
            {
                new Customer()
                {
                    Id = 200,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    IsCorporate = false

                },new Customer()
                {
                    Id = 201,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    IsCorporate = false

                },new Customer()
                {
                    Id = 202,
                    Name = "",
                    PhoneNumber = "",
                    Email = "",
                    IsCorporate = false
                }
            });

            await repo.SaveChangesAsync();
            var collection = await customerService.GetAllAsync();

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(3, Is.EqualTo(collection.Count(c => c.Id >= 100)));
        }

        [Test]
        public async Task TestGetSpecieTypesAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<SpecieType>()
            {
                new SpecieType() { Id = 100, Name = "" },
                new SpecieType() { Id = 103, Name = "" },
                new SpecieType() { Id = 105, Name = "" },
                new SpecieType() { Id = 102, Name = "" }
            });

            await repo.SaveChangesAsync();
            IEnumerable<SpecieType> collection = await customerService.GetSpecieTypesAsync();

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(4, Is.EqualTo(collection.Count(c => c.Id >= 100)));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}