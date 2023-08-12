using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Models.Part;
using RepairShopStudio.Core.Models.ShopService;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.UnitTests
{
    [TestFixture]
    public class ShopServiceServiceUnitTests
    {
        private IRepository repo;
        private ILogger<ShopServiceService> logger;
        private IShopServiceService shopServiceService;
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
        public async Task TestAddAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            var service = new AddShopServiceViewModel
            {
                Id = 100,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            var service1 = new AddShopServiceViewModel
            {
                Id = 101,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            await shopServiceService.AddAsync(service);
            await shopServiceService.AddAsync(service1);
            var collection = applicationDbContext.ShopServices.Count(c => c.Id >= 100);
            Assert.That(2, Is.EqualTo(collection));
        }

        [Test]
        public async Task TestAllVehicleComponentsInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync<VehicleComponent>(new List<VehicleComponent>
            {
                new VehicleComponent
                {
                    Id = 100,
                    Name = "A"
                },
                new VehicleComponent
                {
                    Id = 101,
                    Name = "B"
                },
                new VehicleComponent
                {
                    Id = 102,
                    Name = "Z"
                }
            });

            await repo.SaveChangesAsync();
            var collection = shopServiceService.AllVehicleComponents();
            //Check only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(3, Is.EqualTo(collection.Result.Count(vc => vc.Id >= 100)));
            Assert.That("A", Is.EqualTo(collection.Result.FirstOrDefault()?.Name));
            Assert.That("Z", Is.EqualTo(collection.Result.LastOrDefault()?.Name));
        }

        [Test]
        public async Task TestDeleteInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            var service = new AddShopServiceViewModel
            {
                Id = 100,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            var service1 = new AddShopServiceViewModel
            {
                Id = 101,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            await shopServiceService.AddAsync(service);
            await shopServiceService.AddAsync(service1);
            var collection = repo.AllReadonly<ShopService>();
            Assert.That(2, Is.EqualTo(collection.Count(vc => vc.Id >= 100)));

            await shopServiceService.Delete(service.Id);
            Assert.That(collection.FirstOrDefault(sc => sc.Id == service.Id)?.IsActive, Is.False);
        }

        [Test]
        public async Task TestEditInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            var service = new AddShopServiceViewModel
            {
                Id = 100,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            await shopServiceService.AddAsync(service);

            var result = await shopServiceService.Edit(service.Id, new ShopServiceViewModel()
            {
                Id = 100,
                Name = "Breaks check and repairs EDITED",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            });

            Assert.That(result, Is.True);
            Assert.That(applicationDbContext.ShopServices.Any(p => p.Name.ToUpper().Contains("EDITED")), Is.True);
        }

        [Test]
        public async Task TestExistsInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            var service = new AddShopServiceViewModel
            {
                Id = 100,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            await shopServiceService.AddAsync(service);
            var result = await shopServiceService.Exists(service.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestGetAllAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            var service = new AddShopServiceViewModel
            {
                Id = 100,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            var service1 = new AddShopServiceViewModel
            {
                Id = 101,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            await shopServiceService.AddAsync(service);
            await shopServiceService.AddAsync(service1);

            var result = await shopServiceService.GetAllAsync();
            Assert.That(2, Is.EqualTo(result.Count(vc => vc.Id >= 100)));
        }

        [Test]
        public async Task TestGetVehicleComponentIdInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            var service = new AddShopServiceViewModel
            {
                Id = 100,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            var service1 = new AddShopServiceViewModel
            {
                Id = 101,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 5
            };

            await shopServiceService.AddAsync(service);
            await shopServiceService.AddAsync(service1);

            var id1 = await shopServiceService.GetVehicleComponentId(service.Id);
            Assert.That(4, Is.EqualTo(id1));
            var id2 = await shopServiceService.GetVehicleComponentId(service1.Id);
            Assert.That(5, Is.EqualTo(id2));
        }

        [Test]
        public async Task TestGetVehicleComponentsAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<VehicleComponent>
            {
                new VehicleComponent
                {
                    Id = 100,
                    Name = ""
                },
                new VehicleComponent
                {
                    Id = 101,
                    Name = ""
                }
            });

            await applicationDbContext.SaveChangesAsync();

            var collection = await shopServiceService.GetVehicleComponentsAsync();
            Assert.That(2, Is.EqualTo(collection.Count(vc => vc.Id >= 100)));
        }

        [Test]
        public async Task TestServiceDetailsByIdInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            var service = new AddShopServiceViewModel
            {
                Id = 100,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };

            await shopServiceService.AddAsync(service);
            var result = shopServiceService.ServiceDetailsById(service.Id).Result;
            Assert.That(result.Name, Is.EqualTo(service.Name));

        }

        [Test]
        public async Task TestVehicleComponentExistsInMemory()
        {
            var loggerMock = new Mock<ILogger<ShopServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            shopServiceService = new ShopServiceService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<VehicleComponent>
            {
                new VehicleComponent
                {
                    Id = 100,
                    Name = ""
                },
                new VehicleComponent
                {
                    Id = 101,
                    Name = ""
                }
            });

            await applicationDbContext.SaveChangesAsync();

            var result = await shopServiceService.VehicleComponentExists(100);
            Assert.That(result, Is.True);
            var result2 = await shopServiceService.VehicleComponentExists(101);
            Assert.That(result2, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
