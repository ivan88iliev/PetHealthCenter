using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Services;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.UnitTests
{
    [TestFixture]
    public class PetServiceUnitTests
    {
        private IRepository repo;
        private IPetService animalService;
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
        public async Task TestExistsAsyncInMemory()
        {
            var repo = new Repository(applicationDbContext);
            animalService = new PetService(applicationDbContext, repo);

            var animal = new Pet()
            {
                Id = 100,
                Make = "Labrador",
                Model = "American",
                IdentificationNUmber = "B3333BB",
                FIrstRegistration = DateTime.Parse("2013-06-23"),
                SpecieTypeId = 2,
                Power = 272,
                VinNumber = "12312324125",
            };

            await repo.AddAsync(animal);
            await repo.SaveChangesAsync();
            var result = await animalService.ExistsAsync(animal.IdentificationNUmber);
            Assert.That(result, Is.True);

        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
