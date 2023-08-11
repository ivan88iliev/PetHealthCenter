using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Infrastructure.Data.Configuration
{
    internal class HealthServiceConfiguration : IEntityTypeConfiguration<HealthService>
    {
        public void Configure(EntityTypeBuilder<HealthService> builder)
        {
            builder.HasData(CreateHealthService());
        }

        List<HealthService> CreateHealthService()
        {
            var healthServices = new List<HealthService>();

            var healthService = new HealthService()
            {
                Id = 1,
                Name = "Diagnosis and vaccination",
                Description = "Check the common health status and vaccination",
                Price = 65M,
                ProductComponentId = 4
            };
            healthServices.Add(healthService);

            return healthServices;
        }
    }
}
