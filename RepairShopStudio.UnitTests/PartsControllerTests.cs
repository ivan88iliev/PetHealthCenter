//using Microsoft.EntityFrameworkCore;
//using RepairShopStudio.Infrastructure.Data;
//using RepairShopStudio.Infrastructure.Data.Common;
//using RepairShopStudio.Controllers;
//using RepairShopStudio.Core.Contracts;
//using RepairShopStudio.Core.Services;

//namespace RepairShopStudio.UnitTests
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
//                .UseInMemoryDatabase("RepairShopDB")
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
