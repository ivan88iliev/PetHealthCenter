using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Models.Part;
using PetHealthCenter.Core.Models.HealthService;
using PetHealthCenter.Core.Services;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHealthCenter.UnitTests
{
    [TestFixture]
    public class HealthServiceServiceUnitTests
    {
        private IRepository repo;
        private ILogger<HealthServiceService> logger;
        private IHealthServiceService healthServiceService;
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
        public async Task TestAddAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            var service = new AddHealthServiceViewModel
            {
                Id = 100,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            var service1 = new AddHealthServiceViewModel
            {
                Id = 101,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            await healthServiceService.AddAsync(service);
            await healthServiceService.AddAsync(service1);
            var collection = applicationDbContext.HealthServices.Count(c => c.Id >= 100);
            Assert.That(2, Is.EqualTo(collection));
        }

        [Test]
        public async Task TestAllProductComponentsInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            await repo.AddRangeAsync<ProductComponent>(new List<ProductComponent>
            {
                new ProductComponent
                {
                    Id = 100,
                    Name = "A"
                },
                new ProductComponent
                {
                    Id = 101,
                    Name = "B"
                },
                new ProductComponent
                {
                    Id = 102,
                    Name = "Z"
                }
            });

            await repo.SaveChangesAsync();
            var collection = healthServiceService.AllProductComponents();
            //Check only IDs with value equal or higher than 100 to avoid conflict with seeded objects
            Assert.That(3, Is.EqualTo(collection.Result.Count(vc => vc.Id >= 100)));
            Assert.That("A", Is.EqualTo(collection.Result.FirstOrDefault()?.Name));
            Assert.That("Z", Is.EqualTo(collection.Result.LastOrDefault()?.Name));
        }

        [Test]
        public async Task TestDeleteInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            var service = new AddHealthServiceViewModel
            {
                Id = 100,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            var service1 = new AddHealthServiceViewModel
            {
                Id = 101,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            await healthServiceService.AddAsync(service);
            await healthServiceService.AddAsync(service1);
            var collection = repo.AllReadonly<HealthService>();
            Assert.That(2, Is.EqualTo(collection.Count(vc => vc.Id >= 100)));

            await healthServiceService.Delete(service.Id);
            Assert.That(collection.FirstOrDefault(sc => sc.Id == service.Id)?.IsActive, Is.False);
        }

        [Test]
        public async Task TestEditInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            var service = new AddHealthServiceViewModel
            {
                Id = 100,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            await healthServiceService.AddAsync(service);

            var result = await healthServiceService.Edit(service.Id, new HealthServiceViewModel()
            {
                Id = 100,
                Name = "Diagnosis and vaccination EDITED",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            });

            Assert.That(result, Is.True);
            Assert.That(applicationDbContext.HealthServices.Any(p => p.Name.ToUpper().Contains("EDITED")), Is.True);
        }

        [Test]
        public async Task TestExistsInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            var service = new AddHealthServiceViewModel
            {
                Id = 100,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            await healthServiceService.AddAsync(service);
            var result = await healthServiceService.Exists(service.Id);
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task TestGetAllAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            var service = new AddHealthServiceViewModel
            {
                Id = 100,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            var service1 = new AddHealthServiceViewModel
            {
                Id = 101,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            await healthServiceService.AddAsync(service);
            await healthServiceService.AddAsync(service1);

            var result = await healthServiceService.GetAllAsync();
            Assert.That(2, Is.EqualTo(result.Count(vc => vc.Id >= 100)));
        }

        [Test]
        public async Task TestGetProductComponentIdInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            var service = new AddHealthServiceViewModel
            {
                Id = 100,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            var service1 = new AddHealthServiceViewModel
            {
                Id = 101,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 5
            };

            await healthServiceService.AddAsync(service);
            await healthServiceService.AddAsync(service1);

            var id1 = await healthServiceService.GetProductComponentId(service.Id);
            Assert.That(4, Is.EqualTo(id1));
            var id2 = await healthServiceService.GetProductComponentId(service1.Id);
            Assert.That(5, Is.EqualTo(id2));
        }

        [Test]
        public async Task TestGetProductComponentsAsyncInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<ProductComponent>
            {
                new ProductComponent
                {
                    Id = 100,
                    Name = ""
                },
                new ProductComponent
                {
                    Id = 101,
                    Name = ""
                }
            });

            await applicationDbContext.SaveChangesAsync();

            var collection = await healthServiceService.GetProductComponentsAsync();
            Assert.That(2, Is.EqualTo(collection.Count(vc => vc.Id >= 100)));
        }

        [Test]
        public async Task TestServiceDetailsByIdInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            var service = new AddHealthServiceViewModel
            {
                Id = 100,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };

            await healthServiceService.AddAsync(service);
            var result = healthServiceService.ServiceDetailsById(service.Id).Result;
            Assert.That(result.Name, Is.EqualTo(service.Name));

        }

        [Test]
        public async Task TestProductComponentExistsInMemory()
        {
            var loggerMock = new Mock<ILogger<HealthServiceService>>();
            logger = loggerMock.Object;
            var repo = new Repository(applicationDbContext);
            healthServiceService = new HealthServiceService(applicationDbContext, repo, logger);

            await applicationDbContext.AddRangeAsync(new List<ProductComponent>
            {
                new ProductComponent
                {
                    Id = 100,
                    Name = ""
                },
                new ProductComponent
                {
                    Id = 101,
                    Name = ""
                }
            });

            await applicationDbContext.SaveChangesAsync();

            var result = await healthServiceService.ProductComponentExists(100);
            Assert.That(result, Is.True);
            var result2 = await healthServiceService.ProductComponentExists(101);
            Assert.That(result2, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            applicationDbContext.Dispose();
        }
    }
}
