using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.UnitTests
{
    [TestFixture]
    public class VehicleServiceUnitTests
    {
        private IRepository repo;
        private IVehicleService vehicleService;
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
        public async Task TestExistsAsyncInMemory()
        {
            var repo = new Repository(applicationDbContext);
            vehicleService = new VehicleService(applicationDbContext, repo);

            var vehicle = new Vehicle()
            {
                Id = 100,
                Make = "Mercedes-Benz",
                Model = "W164 350",
                LicensePLate = "B3333BB",
                FIrstRegistration = DateTime.Parse("2013-06-23"),
                EngineTypeId = 2,
                Power = 272,
                VinNumber = "12312324125",
            };

            await repo.AddAsync(vehicle);
            await repo.SaveChangesAsync();
            var result = await vehicleService.ExistsAsync(vehicle.LicensePLate);
            Assert.That(result, Is.True);

        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
