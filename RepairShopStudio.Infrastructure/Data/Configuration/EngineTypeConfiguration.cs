using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class EngineTypeConfiguration : IEntityTypeConfiguration<EngineType>
    {
        public void Configure(EntityTypeBuilder<EngineType> builder)
        {
            builder.HasData(CreateEngineType());
        }

        List<EngineType> CreateEngineType()
        {
            var engineTypes = new List<EngineType>();

            var gasolineEngine = new EngineType()
            {
                Id = 1,
                Name = "Gasoline"
            };

            engineTypes.Add(gasolineEngine);

            var dieselEngine = new EngineType()
            {
                Id = 2,
                Name = "Diesel"
            };

            engineTypes.Add(dieselEngine);

            var hybridEngine = new EngineType()
            {
                Id = 3,
                Name = "Hybrid"
            };

            engineTypes.Add(hybridEngine);

            var electricEngine = new EngineType()
            {
                Id = 4,
                Name = "Electric"
            };

            engineTypes.Add(electricEngine);

            return engineTypes;
        }
    }
}
