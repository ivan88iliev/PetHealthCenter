//using Microsoft.EntityFrameworkCore;
//using PetHealthCenter.Infrastructure.Data;
//using PetHealthCenter.Infrastructure.Data.Common;
//using PetHealthCenter.Controllers;
//using PetHealthCenter.Core.Contracts;
//using PetHealthCenter.Core.Services;

//namespace PetHealthCenter.UnitTests
//{
//    [TestFixture]
//    public class PartsControllerTests
//    {
//        private IRepository repo;
//        private ApplicationDbContext applicationDbContext;
//        private PartsController partsController;
//        private IPartService partService;

//        [SetUp]
//        public void Setup()
//        {
//            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
//                .UseInMemoryDatabase("PetHealthDB")
//                .Options;

//            applicationDbContext = new ApplicationDbContext(contextOptions);

//            partsController = new PartsController(partService, applicationDbContext);

//            applicationDbContext.Database.EnsureDeleted();
//            applicationDbContext.Database.EnsureCreated();
//        }

//        [Test]
//        public async Task TestAddInMemory()
//        {
//            var repo = new Repository(applicationDbContext);
//            partsController = new PartsController(partService, applicationDbContext);

//            var result = partsController.Add();

//            Assert.That(result, Is.Not.Null);
//        }


//        [TearDown]
//        public void TearDown()
//        {
//            applicationDbContext.Dispose();
//        }
//    }

//}
