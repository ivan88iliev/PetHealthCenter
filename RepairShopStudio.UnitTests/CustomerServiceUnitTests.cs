using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Address;
using RepairShopStudio.Core.Models.CustomerModels;
using RepairShopStudio.Core.Models.EngineType;
using RepairShopStudio.Core.Models.Vehicle;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.UnitTests
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
                .UseInMemoryDatabase("RepairShopDB")
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
                Vehicle = new VehicleAddViewModel()
                {
                    Id = 100,
                    Make = "Test",
                    Model = "Test",
                    VinNumber = "1111111111111",
                    Power = 100,
                    EngineTypeId = 1,
                    LicensePLate = "B3333BB",
                    FIrstRegistration = DateTime.Today
                }
            };

            await customerService.AddCorporateCutomerAsync(customerModel);

            Assert.That(applicationDbContext.Addresses.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Vehicles.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.Any(c => c.AddressId == customerModel.Address.Id), Is.True);

            Assert.That(applicationDbContext.Customers.FirstOrDefault(c => c.Id == customerModel.Id)?.Vehicles
                .Any(v => v.Id == customerModel.Vehicle.Id), Is.True);

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
                Vehicle = new VehicleAddViewModel()
                {
                    Id = 110,
                    Make = "Test",
                    Model = "Test",
                    VinNumber = "1111111111111",
                    Power = 100,
                    EngineTypeId = 1,
                    LicensePLate = "B3333BB",
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
                Vehicle = new VehicleAddViewModel()
                {
                    Id = 100,
                    Make = "Test",
                    Model = "Test",
                    VinNumber = "1111111111111",
                    Power = 100,
                    EngineTypeId = 1,
                    LicensePLate = "B3333BB",
                    FIrstRegistration = DateTime.Today
                }
            };

            await customerService.AddRegularCutomerAsync(customerModel);

            Assert.That(applicationDbContext.Customers.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Vehicles.Any(a => a.Id == 100), Is.True);
            Assert.That(applicationDbContext.Customers.FirstOrDefault(c => c.Id == customerModel.Id)?.Vehicles
                .Any(v => v.Id == customerModel.Vehicle.Id), Is.True);


            var customerModelEx = new CustomerAddViewModel()
            {
                Id = 110,
                Name = "Test Test",
                Email = "test@mail.bg",
                PhoneNumber = "+35900000000",
                IsCorporate = true,
                ResponsiblePerson = "Test Test",
                Uic = "111111111",
                Vehicle = null
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
        public async Task TestAllEngineTypesAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<EngineType>()
            {
                new EngineType() { Id = 100, Name = "" },
                new EngineType() { Id = 103, Name = "" },
                new EngineType() { Id = 105, Name = "" },
                new EngineType() { Id = 102, Name = "" }
            });

            await repo.SaveChangesAsync();
            IEnumerable<EngineTypeViewModel> collection = await customerService.AllEngineTypesAsync();

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
        public async Task TestGetEngineTypesAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<CustomerService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            customerService = new CustomerService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<EngineType>()
            {
                new EngineType() { Id = 100, Name = "" },
                new EngineType() { Id = 103, Name = "" },
                new EngineType() { Id = 105, Name = "" },
                new EngineType() { Id = 102, Name = "" }
            });

            await repo.SaveChangesAsync();
            IEnumerable<EngineType> collection = await customerService.GetEngineTypesAsync();

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