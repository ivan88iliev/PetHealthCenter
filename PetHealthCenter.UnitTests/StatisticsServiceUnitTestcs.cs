using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetHealthCenter.Core.Services;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.UnitTests
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
            .UseInMemoryDatabase("PetHealthDB")
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
                    Name = "Cosequin Maximum Strength Tablets",
                    ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                    Stock = 4,
                    Manufacturer = "Cosequin",
                    OriginalMpn = "CHEWDS250-MSM-2PK",
                    Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                    PriceBuy = 99.98M,
                    PriceSell = 114.56M,
                    ProductComponentId = 2
                },new Part()
                {
                    Id = 101,
                    Name = "Cosequin Maximum Strength Tablets",
                    ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                    Stock = 4,
                    Manufacturer = "Cosequin",
                    OriginalMpn = "CHEWDS250-MSM-2PK",
                    Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                    PriceBuy = 99.98M,
                    PriceSell = 114.56M,
                    ProductComponentId = 2
                },
            });

            await repo.AddRangeAsync(new List<HealthService>()
            {
                new HealthService() 
                {
                    Id = 100,
                    Name = "Diagnosis and vaccination",
                    Description = "Check the common health status and vaccination",
                    Price = 65M,
                    ProductComponentId = 4
                },
                new HealthService()
                {
                    Id = 101,
                    Name = "Diagnosis and vaccination",
                    Description = "Check the common health status and vaccination",
                    Price = 65M,
                    ProductComponentId = 4
                },
                new HealthService()
                {
                    Id = 102,
                    Name = "Diagnosis and vaccination",
                    Description = "Check the common health status and vaccination",
                    Price = 65M,
                    ProductComponentId = 4
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
                    PetId = 1
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
                    PetId = 1
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
                    PetId = 1
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
                    PetId = 1
                }
            });

            await repo.SaveChangesAsync();

            var result = statisticsService.Total().Result;

            Assert.That(repo.AllReadonly<Part>(p => p.Id >= 100).Count() + 1, Is.EqualTo(result.TotalParts));
            Assert.That(repo.AllReadonly<HealthService>(p => p.Id >= 100).Count() + 1, Is.EqualTo(result.TotalServices));
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
