using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.OperatingCard;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;
using RepairShopStudio.Infrastructure.Data.Models.User;

namespace RepairShopStudio.UnitTests
{
    [TestFixture]
    public class OperatingCardServiceUnitTests
    {
        private IRepository repo;
        private ILogger<OperatingCardService> logger;
        private IOperatingCardService cardService;
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
        public async Task TestGetAllAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            //await applicationDbContext.AddRangeAsync(new List<OperatingCard>
            //{
            //    new OperatingCard() { Id = 100, CustomerId = 100, VehicleId = 100, PartId = 100, ServiceId = 100, ApplicationUserId = Guid.Parse("265f6e7d-6b6e-43e8-b385-19315ca888f9"), IsActive = true, DocumentNumber = "" },
            //    new OperatingCard() { Id = 101, CustomerId = 101, VehicleId = 101, PartId = 101, ServiceId = 101, ApplicationUserId = Guid.Parse("265f6e7d-6b6e-43e8-b385-19123ca888f9"), IsActive = true, DocumentNumber = "" }
            //});

            //await applicationDbContext.SaveChangesAsync();

            var operatingCard = new OperatingCardAddViewModel()
            {
                Id = 100,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = "59bff60d-d8d8-4ca8-9da9-48149761e9db",
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = true,
                IssueDate = DateTime.Today
            };

            await cardService.AddOperatingCardAsync(operatingCard);

            var operatingCard2 = new OperatingCardAddViewModel()
            {
                Id = 101,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = "59bff60d-d8d8-4ca8-9da9-48149761e9db",
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = true,
                IssueDate = DateTime.Today
            };

            await cardService.AddOperatingCardAsync(operatingCard2);

            var operatingCard3 = new OperatingCardAddViewModel()
            {
                Id = 102,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = "59bff60d-d8d8-4ca8-9da9-48149761e9db",
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = true,
                IssueDate = DateTime.Today
            };

            await cardService.AddOperatingCardAsync(operatingCard3);

            var collection = cardService.GetAllAsync().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(3, Is.EqualTo(collection.Count(c => c.Id >= 100)));
        }

        [Test]
        public async Task TestGetShopServicesAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<ShopService>
            {
                new ShopService() { Id = 100, Name = "", Description = ""},
                new ShopService() { Id = 101, Name = "", Description = "" }
            });

            await applicationDbContext.SaveChangesAsync();
            var collection = cardService.GetShopServicesAsync().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(2, Is.EqualTo(collection.Count(s => s.Id >= 100)));
        }

        [Test]
        public async Task TestGetGetPartsAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<Part>
            {
                new Part() { Id = 100, Name = "", Description = "", Manufacturer = "", OriginalMpn = ""},
                new Part() { Id = 101, Name = "", Description = "", Manufacturer = "", OriginalMpn = "" }
            });

            await applicationDbContext.SaveChangesAsync();
            var collection = cardService.GetPartsAsync().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(2, Is.EqualTo(collection.Count(s => s.Id >= 100)));
        }

        [Test]
        public async Task TestGetMechanicsAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<ApplicationUser>
            {
                new ApplicationUser() { Id = Guid.Parse("65fc2044-7cfb-43fc-8c68-0efa6b6d421a"), Email = "", UserName = "mechanic1"},
                new ApplicationUser() { Id = Guid.Parse("65fc2044-929f-4131-a6ef-5d32bd793a21"), Email = "", UserName = "mechanic2"}
            });

            await applicationDbContext.SaveChangesAsync();
            var collection = cardService.GetMechanicsAsync().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(2, Is.EqualTo(collection.Count(s => s.Id.ToString().StartsWith("65fc2044"))));
        }

        [Test]
        public async Task TestGetCustomerVehiclesInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            var customer = new Customer()
            {
                Id = 100,
                Name = string.Empty,
                Email = string.Empty,
                PhoneNumber = string.Empty,
                IsCorporate = false
            };

            await applicationDbContext.AddAsync(customer);

            var vehicle = new Vehicle()
            {
                Id = 100,
                Make = string.Empty,
                Model = string.Empty,
                LicensePLate = string.Empty,
                Power = 50,
                VinNumber = string.Empty,
                CustomerId = customer.Id,
                FIrstRegistration = DateTime.Today,
                EngineTypeId = 1
            };
            await applicationDbContext.AddAsync(vehicle);

            var vehicle2 = new Vehicle()
            {
                Id = 101,
                Make = string.Empty,
                Model = string.Empty,
                LicensePLate = string.Empty,
                Power = 50,
                VinNumber = string.Empty,
                CustomerId = customer.Id,
                FIrstRegistration = DateTime.Today,
                EngineTypeId = 1
            };

            await applicationDbContext.AddAsync(vehicle2);
            await applicationDbContext.SaveChangesAsync();

            var collection = await cardService.GetCustomerVehicles(customer.Id);
            Assert.That(2, Is.EqualTo(collection.Count(v => v.CustomerId == customer.Id)));
        }

        [Test]
        public async Task TestMarkRepairAsFinishedAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            var user = new ApplicationUser() { Id = Guid.Parse("65fc2044-7cfb-43fc-8c68-0efa6b6d421a"), Email = "", UserName = "mechanic1" };
            await applicationDbContext.AddAsync(user);

            var part = new Part() { Id = 100, Name = "", Description = "", Manufacturer = "", OriginalMpn = "", Stock = 4 };
            await applicationDbContext.AddAsync(part);

            var card = new OperatingCard() { Id = 100, CustomerId = 100, VehicleId = 100, PartId = part.Id, ServiceId = 100, ApplicationUserId = user.Id, IsActive = true, DocumentNumber = "" };
            await applicationDbContext.AddAsync(card);

            await applicationDbContext.SaveChangesAsync();
            await cardService.MarkRepairAsFinishedAsync(card.Id, user.Id.ToString());

            Assert.That(true, Is.EqualTo(card.IsActive == false));
            Assert.That(3, Is.EqualTo(part.Stock));

        }

        [Test]
        public async Task TestGetCustomersAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<Customer>
            {
                new Customer()
                {
                    Id = 100,
                    Name = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,
                    IsCorporate = false
                },
                new Customer()
                {
                    Id = 101,
                    Name = string.Empty,
                    Email = string.Empty,
                    PhoneNumber = string.Empty,
                    IsCorporate = false
                },
            });

            await applicationDbContext.SaveChangesAsync();
            var collection = cardService.GetCustomersAsync().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(2, Is.EqualTo(collection.Count(s => s.Id >= 100)));
        }

        [Test]
        public async Task TestGetCustomerNameByIdInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);


            var customer = new Customer()
            {
                Id = 100,
                Name = "Emil Petrov",
                Email = string.Empty,
                PhoneNumber = string.Empty,
                IsCorporate = false
            };

            await applicationDbContext.AddAsync(customer);
            await applicationDbContext.SaveChangesAsync();
            await cardService.GetCustomerNameById(customer.Id);

            Assert.That("Emil Petrov", Is.EqualTo(applicationDbContext.Customers.FirstOrDefault(c => c.Id == customer.Id).Name));
        }

        [Test]
        public async Task TestGetAllFinishedAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);


            var card1 = new OperatingCard()
            {
                Id = 100,
                Date = DateTime.Now.Date,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = false
            };
            await applicationDbContext.AddAsync(card1);

            var card2 = new OperatingCard()
            {
                Id = 101,
                Date = DateTime.Now.Date,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = false
            };
            await applicationDbContext.AddAsync(card2);

            var card3 = new OperatingCard()
            {
                Id = 102,
                Date = DateTime.Now.Date,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
            };

            await applicationDbContext.AddAsync(card3);

            await applicationDbContext.SaveChangesAsync();
            var collection = cardService.GetAllFinishedAsync().Result;

            Assert.That(2, Is.EqualTo(collection.Count()));
        }

        [Test]
        public async Task TestAddOperatingCardAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<OperatingCardService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            cardService = new OperatingCardService(applicationDbContext, repo, logger);

            var operatingCard = new OperatingCardAddViewModel()
            {
                Id = 100,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = "59bff60d-d8d8-4ca8-9da9-48149761e9db",
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = true,
                IssueDate = DateTime.Today
            };

            await cardService.AddOperatingCardAsync(operatingCard);

            var operatingCard2 = new OperatingCardAddViewModel()
            {
                Id = 101,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = "59bff60d-d8d8-4ca8-9da9-48149761e9db",
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = true,
                IssueDate = DateTime.Today
            };

            await cardService.AddOperatingCardAsync(operatingCard2);

            var operatingCard3 = new OperatingCardAddViewModel()
            {
                Id = 102,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = "59bff60d-d8d8-4ca8-9da9-48149761e9db",
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
                IsActive = true,
                IssueDate = DateTime.Today
            };

            await cardService.AddOperatingCardAsync(operatingCard3);

            Assert.That(3, Is.EqualTo(applicationDbContext.OperatingCards.Count(c => c.Id >= 100)));
        }


        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}

