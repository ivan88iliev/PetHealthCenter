using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Services;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetHealthCenter.Core.Models.Part;
using Moq;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.UnitTests
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
                .UseInMemoryDatabase("PetHealthDB")
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

            varmedical products= applicationDbContext.Parts.Where(p => p.Manufacturer.Contains(searchTerm));
            Assert.That(result.Result.TotalPartsCount, Is.EqualTo(medProducts.Count()));
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
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
            };

            var part1 = new AddPartViewModel
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
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
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

            varmedical products= new List<Part>()
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
                    ProductComponentId =1,
                    IsActive = true
                },
                new Part()
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
                    ProductComponentId = 2,
                    IsActive = true
                },
                new Part()
                {
                    Id = 103,
                    Name = "Cosequin Maximum Strength Tablets",
                    ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                    Stock = 4,
                    Manufacturer = "Cosequin",
                    OriginalMpn = "CHEWDS250-MSM-2PK",
                    Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                    PriceBuy = 99.98M,
                    PriceSell = 114.56M,
                    ProductComponentId = 3,
                    IsActive = false
                },
            };

            await applicationDbContext.AddRangeAsync(medProducts);
            await applicationDbContext.SaveChangesAsync();

            var result = partService.GetAllAsync().Result.Count(p => p.Id >= 100);
            Assert.That(result, Is.EqualTo(2));

        }

        [Test]
        public async Task TestGetProductComponentsAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<ProductComponent>
            {
                new ProductComponent()
                {
                    Id = 100,
                    Name = ""
                },
                new ProductComponent()
                {
                    Id = 101,
                    Name = ""
                }
            });

            await applicationDbContext.SaveChangesAsync();
            var collection = partService.GetProductComponentsAsync().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(2, Is.EqualTo(collection.Count(p => p.Id >= 100)));
        }

        [Test]
        public async Task TestGetProductComponentIdInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            var part = new AddPartViewModel
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
            };
            await partService.AddPartAsync(part);

            var animalComponentId = await partService.GetProductComponentId(part.Id);
            Assert.That(2, Is.EqualTo(animalComponentId));
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
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
            };
            await partService.AddPartAsync(part);
            var result = partService.PartDetailsById(part.Id).Result;
            Assert.That(result.Name, Is.EqualTo(part.Name));
        }

        [Test]
        public async Task TestAllProductComponentsInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<ProductComponent>
            {
                new ProductComponent()
                {
                    Id = 100,
                    Name = ""
                },
                new ProductComponent()
                {
                    Id = 101,
                    Name = ""
                },
                new ProductComponent()
                {
                    Id = 102,
                    Name = ""
                }
            });

            await repo.SaveChangesAsync();
            var collection = partService.AllProductComponents().Result;

            //Collect only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(3, Is.EqualTo(collection.Count(p => p.Id >= 100)));
        }

        [Test]
        public async Task TestProductComponentExistsInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<ProductComponent>
            {
                new ProductComponent()
                {
                    Id = 100,
                    Name = ""
                },
                new ProductComponent()
                {
                    Id = 101,
                    Name = ""
                },
                new ProductComponent()
                {
                    Id = 102,
                    Name = ""
                }
            });

            await repo.SaveChangesAsync();
            var vc1 = await partService.ProductComponentExists(100);
            var vc2 = await partService.ProductComponentExists(101);
            var vc3 = await partService.ProductComponentExists(102);
            var vc4 = await partService.ProductComponentExists(103);

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
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
            };
            await partService.AddPartAsync(part);

            var result = await partService.Edit(100, new PartViewModel()
            {
                Id = 100,
                Name = "Cosequin Maximum Strength Tablets EDITED",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
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
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
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
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
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
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
            };

            await partService.AddPartAsync(part);
            Assert.That(applicationDbContext.Parts.Any(a => a.Id == part.Id), Is.True);
            await partService.Delete(part.Id);
            Assert.That(applicationDbContext.Parts.FirstOrDefaultAsync(p => p.Id == part.Id).Result.IsActive == false, Is.True);
        }

        [Test]
        public async Task TestAllProductComponentsNamesInMemory()
        {
            var loggerMock = new Mock<ILogger<PartService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            partService = new PartService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync(new List<ProductComponent>
            {
                new ProductComponent()
                {
                    Id = 100,
                    Name = "Test1"
                },
                new ProductComponent()
                {
                    Id = 101,
                    Name = "Test2"
                },
                new ProductComponent()
                {
                    Id = 102,
                    Name = "Test3"
                }
            });

            await repo.SaveChangesAsync();
            var collection = await partService.AllProductComponentsNames();
            Assert.That(applicationDbContext.ProductComponents.Any(p => p.Name == "Test1"), Is.True);
            Assert.That(applicationDbContext.ProductComponents.Any(p => p.Name == "Test2"), Is.True);
            Assert.That(applicationDbContext.ProductComponents.Any(p => p.Name == "Test3"), Is.True);
            Assert.That(applicationDbContext.ProductComponents.Any(p => p.Name == "Test5"), Is.False);
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
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
            };

            await partService.AddPartAsync(part);

            var part1 = new AddPartViewModel
            {
                Id = 101,
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Castrol",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
            };

            await partService.AddPartAsync(part1);

            var collection = await partService.AllManufacturers();
            Assert.That(2, Is.EqualTo(collection.Count()));
            Assert.That(collection.FirstOrDefault("Castrol"), Is.Not.Null);
            Assert.That(collection.FirstOrDefault("Cosequin"), Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
