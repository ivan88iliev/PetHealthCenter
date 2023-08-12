using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Infrastructure.Data.Configuration
{
    internal class SpecieTypeConfiguration : IEntityTypeConfiguration<SpecieType>
    {
        public void Configure(EntityTypeBuilder<SpecieType> builder)
        {
            builder.HasData(CreateSpecieType());
        }

        List<SpecieType> CreateSpecieType()
        {
            var specieTypes = new List<SpecieType>();

            var gasolineSpecie = new SpecieType()
            {
                Id = 1,
                Name = "Gasoline"
            };

            specieTypes.Add(gasolineSpecie);

            var dieselSpecie = new SpecieType()
            {
                Id = 2,
                Name = "Diesel"
            };

            specieTypes.Add(dieselSpecie);

            var hybridSpecie = new SpecieType()
            {
                Id = 3,
                Name = "Hybrid"
            };

            specieTypes.Add(hybridSpecie);

            var electricSpecie = new SpecieType()
            {
                Id = 4,
                Name = "Electric"
            };

            specieTypes.Add(electricSpecie);

            return specieTypes;
        }
    }
}
