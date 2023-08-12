using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairShopStudio.Core.Models.Part;
using Moq;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.UnitTests
{
    [TestFixture]
    public class PartServiceUnitTests
    {
        private IRepository repo;
        private ILogger<PartService> logger;
        private IPartService partService;
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
        public async Task TestAllInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);


            var searchTerm = "castrol";
            var result = partService.AllAsync(null, searchTerm);

            var parts = applicationDbContext.Parts.Where(p => p.Manufacturer.Contains(searchTerm));
            Assert.That(result.Result.TotalPartsCount, Is.EqualTo(parts.Count()));
        }

        [Test]
        public async Task TestAddPartAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };

            var part1 = new AddPartViewModel
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
            };

            await partService.AddPartAsync(part);
            await partService.AddPartAsync(part1);
            var collection = applicationDbContext.Parts.Count(c => c.Id >= 100);
            Assert.That(2, Is.EqualTo(collection));
        }

        [Test]
        public async Task TestExistsInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };

            await partService.AddPartAsync(part);
            var result = await partService.Exists(part.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestGetAllAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var parts = new List<Part>()
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
                    VehicleComponentId =1,
                    IsActive = true
                },
                new Part()
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
                    VehicleComponentId = 2,
                    IsActive = true
                },
                new Part()
                {
                    Id = 103,
                    Name = "Sport Brake Disc for MERCEDES-BENZ M-KLASSE (W164)",
                    ImageUrl = "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg",
                    Stock = 4,
                    Manufacturer = "Zimmerman",
                    OriginalMpn = "400.3649.52",
                    Description = "Front",
                    PriceBuy = 99.98M,
                    PriceSell = 114.56M,
                    VehicleComponentId = 3,
                    IsActive = false
                },
            };

            await applicationDbContext.AddRangeAsync(parts);
            await applicationDbContext.SaveChangesAsync();

            var result = partService.GetAllAsync().Result.Count(p => p.Id >= 100);
            Assert.That(result, Is.EqualTo(2));

        }

        [Test]
        public async Task TestGetVehicleComponentsAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<VehicleComponent>
            {
                new VehicleComponent()
                {
                    Id = 100,
                    Name = ""
                },
                new VehicleComponent()
                {
                    Id = 101,
                    Name = ""
                }
            });

            await applicationDbContext.SaveChangesAsync();
            var collection = partService.GetVehicleComponentsAsync().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(2, Is.EqualTo(collection.Count(p => p.Id >= 100)));
        }

        [Test]
        public async Task TestGetVehicleComponentIdInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };
            await partService.AddPartAsync(part);

            var vehicleComponentId = await partService.GetVehicleComponentId(part.Id);
            Assert.That(2, Is.EqualTo(vehicleComponentId));
        }

        [Test]
        public async Task TestPartDetailsByIdInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
            {
                Id = 100,
                Name = "Test part",
                ImageUrl = "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg",
                Stock = 4,
                Manufacturer = "Zimmerman",
                OriginalMpn = "400.3649.52",
                Description = "Front",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                VehicleComponentId = 2
            };
            await partService.AddPartAsync(part);
            var result = partService.PartDetailsById(part.Id).Result;
            Assert.That(result.Name, Is.EqualTo(part.Name));
        }

        [Test]
        public async Task TestAllVehicleComponentsInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<VehicleComponent>
            {
                new VehicleComponent()
                {
                    Id = 100,
                    Name = ""
                },
                new VehicleComponent()
                {
                    Id = 101,
                    Name = ""
                },
                new VehicleComponent()
                {
                    Id = 102,
                    Name = ""
                }
            });

            await repo.SaveChangesAsync();
            var collection = partService.AllVehicleComponents().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(3, Is.EqualTo(collection.Count(p => p.Id >= 100)));
        }

        [Test]
        public async Task TestVehicleComponentExistsInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<VehicleComponent>
            {
                new VehicleComponent()
                {
                    Id = 100,
                    Name = ""
                },
                new VehicleComponent()
                {
                    Id = 101,
                    Name = ""
                },
                new VehicleComponent()
                {
                    Id = 102,
                    Name = ""
                }
            });

            await repo.SaveChangesAsync();
            var vc1 = await partService.VehicleComponentExists(100);
            var vc2 = await partService.VehicleComponentExists(101);
            var vc3 = await partService.VehicleComponentExists(102);
            var vc4 = await partService.VehicleComponentExists(103);

            //Check only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(vc1, Is.True);
            Assert.That(vc2, Is.True);
            Assert.That(vc3, Is.True);
            Assert.That(vc4, Is.False);
        }

        [Test]
        public async Task TestEditInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };
            await partService.AddPartAsync(part);

            var result = await partService.Edit(100, new PartViewModel()
            {
                Id = 100,
                Name = "Sport Brake Disc for MERCEDES-BENZ M-KLASSE (W164) EDITED",
                ImageUrl = "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg",
                Stock = 4,
                Manufacturer = "Zimmerman",
                OriginalMpn = "400.3649.52",
                Description = "Front",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                VehicleComponentId = 2
            });

            Assert.That(result, Is.True);
            Assert.That(applicationDbContext.Parts.Any(p => p.Name.ToUpper().Contains("EDITED")), Is.True);
        }

        [Test]
        public async Task TestGetPartForEditAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };

            await partService.AddPartAsync(part);

            var partForEdit = await partService.GetPartForEditAsync(part.Id);

            Assert.That(partForEdit.Id, Is.EqualTo(part.Id));
        }

        [Test]
        public async Task TestGetPartByIdInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };

            await partService.AddPartAsync(part);

            var partForEdit = await partService.GetPartById(part.Id);

            Assert.That(partForEdit.Id, Is.EqualTo(part.Id));
        }

        [Test]
        public async Task TestDeleteInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };

            await partService.AddPartAsync(part);
            Assert.That(applicationDbContext.Parts.Any(a => a.Id == part.Id), Is.True);
            await partService.Delete(part.Id);
            Assert.That(applicationDbContext.Parts.FirstOrDefaultAsync(p => p.Id == part.Id).Result.IsActive == false, Is.True);
        }

        [Test]
        public async Task TestAllVehicleComponentsNamesInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<VehicleComponent>
            {
                new VehicleComponent()
                {
                    Id = 100,
                    Name = "Test1"
                },
                new VehicleComponent()
                {
                    Id = 101,
                    Name = "Test2"
                },
                new VehicleComponent()
                {
                    Id = 102,
                    Name = "Test3"
                }
            });

            await repo.SaveChangesAsync();
            var collection = await partService.AllVehicleComponentsNames();
            Assert.That(applicationDbContext.VehicleComponents.Any(p => p.Name == "Test1"), Is.True);
            Assert.That(applicationDbContext.VehicleComponents.Any(p => p.Name == "Test2"), Is.True);
            Assert.That(applicationDbContext.VehicleComponents.Any(p => p.Name == "Test3"), Is.True);
            Assert.That(applicationDbContext.VehicleComponents.Any(p => p.Name == "Test5"), Is.False);
        }

        [Test]
        public async Task TestAllManufacturersInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };

            await partService.AddPartAsync(part);

            var part1 = new AddPartViewModel
            {
                Id = 101,
                Name = "Sport Brake Disc for MERCEDES-BENZ M-KLASSE (W164)",
                ImageUrl = "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg",
                Stock = 4,
                Manufacturer = "Castrol",
                OriginalMpn = "400.3649.52",
                Description = "Front",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                VehicleComponentId = 2
            };

            await partService.AddPartAsync(part1);

            var collection = await partService.AllManufacturers();
            Assert.That(2, Is.EqualTo(collection.Count()));
            Assert.That(collection.FirstOrDefault("Castrol"), Is.Not.Null);
            Assert.That(collection.FirstOrDefault("Zimmerman"), Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
