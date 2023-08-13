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

            var dogSpecie = new SpecieType()
            {
                Id = 1,
                Name = "Dog"
            };

            specieTypes.Add(dogSpecie);

            var catSpecie = new SpecieType()
            {
                Id = 2,
                Name = "Cat"
            };

            specieTypes.Add(catSpecie);

            var hamsterSpecie = new SpecieType()
            {
                Id = 3,
                Name = "Hamster"
            };

            specieTypes.Add(hamsterSpecie);

            var birdSpecie = new SpecieType()
            {
                Id = 4,
                Name = "Bird"
            };

            specieTypes.Add(birdSpecie);

            return specieTypes;
        }
    }
}
