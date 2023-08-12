using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.UnitTests
{
    public class StatisticsServiceUnitTestcs
    {
        private IRepository repo;
        private IStatisticsService statisticsService;
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
        public async Task TestTotalInMemory()
        {
            var repo = new Repository(applicationDbContext);
            statisticsService = new StatisticsService(applicationDbContext, repo);

            await repo.AddRangeAsync(new List<Part>()
            {
                new Part()
                {
                    Id = 100,
                    Name = "Sport Brake Disc for MERCEDES-BENZ M-KLASSE (W164)",
                    ImageUrl = "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg",
                    Stock = 4,
                    Manufacturer = "Zimmerman",
                    OriginalMpn = "400.3649.52",
                    Description = "Front",
                    PriceBuy = 99.98M,
                    PriceSell = 114.56M,
                    VehicleComponentId = 2
                },new Part()
                {
                    Id = 101,
                    Name = "Sport Brake Disc for MERCEDES-BENZ M-KLASSE (W164)",
                    ImageUrl = "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg",
                    Stock = 4,
                    Manufacturer = "Zimmerman",
                    OriginalMpn = "400.3649.52",
                    Description = "Front",
                    PriceBuy = 99.98M,
                    PriceSell = 114.56M,
                    VehicleComponentId = 2
                },
            });

            await repo.AddRangeAsync(new List<ShopService>()
            {
                new ShopService() 
                {
                    Id = 100,
                    Name = "Breaks check and repairs",
                    Description = "Check all compnents in breaking sistem and repairing those that need it",
                    Price = 65M,
                    VehicleComponentId = 4
                },
                new ShopService()
                {
                    Id = 101,
                    Name = "Breaks check and repairs",
                    Description = "Check all compnents in breaking sistem and repairing those that need it",
                    Price = 65M,
                    VehicleComponentId = 4
                },
                new ShopService()
                {
                    Id = 102,
                    Name = "Breaks check and repairs",
                    Description = "Check all compnents in breaking sistem and repairing those that need it",
                    Price = 65M,
                    VehicleComponentId = 4
                }
            });

            await repo.AddRangeAsync(new List<Customer>()
            {
                new Customer
                {
                    Id = 100,
                    Name = "Ivanov.Inc",
                    PhoneNumber = "099999999",
                    Email = "ivan.ivanov@abv.bg",
                    IsCorporate = true,
                    Uic = "1234543421234",
                    AddressId = 1,
                    ResponsiblePerson = "Ivan Ivanov"
                }
            });

            await repo.AddRangeAsync(new List<OperatingCard>() 
            {
                new OperatingCard()
                {
                    Id = 100,
                    Date = DateTime.Now.Date,
                    DocumentNumber = $"B5466HA/06.12.2022",
                    CustomerId = 1,
                    ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                    PartId = 1,
                    ServiceId = 1,
                    VehicleId = 1
                },
                new OperatingCard()
                {
                    Id = 101,
                    Date = DateTime.Now.Date,
                    DocumentNumber = $"B5466HA/06.12.2022",
                    CustomerId = 1,
                    ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                    PartId = 1,
                    ServiceId = 1,
                    VehicleId = 1
                },
                new OperatingCard()
                {
                    Id = 102,
                    Date = DateTime.Now.Date,
                    DocumentNumber = $"B5466HA/06.12.2022",
                    CustomerId = 1,
                    ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                    PartId = 1,
                    ServiceId = 1,
                    VehicleId = 1
                },
                new OperatingCard()
                {
                    Id = 103,
                    Date = DateTime.Now.Date,
                    DocumentNumber = $"B5466HA/06.12.2022",
                    CustomerId = 1,
                    ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                    PartId = 1,
                    ServiceId = 1,
                    VehicleId = 1
                }
            });

            await repo.SaveChangesAsync();

            var result = statisticsService.Total().Result;

            Assert.That(repo.AllReadonly<Part>(p => p.Id >= 100).Count() + 1, Is.EqualTo(result.TotalParts));
            Assert.That(repo.AllReadonly<ShopService>(p => p.Id >= 100).Count() + 1, Is.EqualTo(result.TotalServices));
            Assert.That(repo.AllReadonly<Customer>(p => p.Id >= 100).Count() + 2, Is.EqualTo(result.TotalCustomers));
            Assert.That(repo.AllReadonly<OperatingCard>(p => p.Id >= 100).Count() + 1, Is.EqualTo(result.TotalOperatingCards));
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
