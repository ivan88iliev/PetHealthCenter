using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Infrastructure.Data.Configuration
{
    internal class ProductComponentConfiguration : IEntityTypeConfiguration<ProductComponent>
    {
        public void Configure(EntityTypeBuilder<ProductComponent> builder)
        {
            builder.HasData(CreateProductComponent());
        }

        List<ProductComponent> CreateProductComponent()
        {
            var animalComponents = new List<ProductComponent>();

            var engnie = new ProductComponent()
            {
                Id = 1,
                Name = "Specie"
            };
            animalComponents.Add(engnie);

            var transmissionSystem = new ProductComponent()
            {
                Id = 2,
                Name = "Tablets"
            };
            animalComponents.Add(transmissionSystem);

            var frontAndRearAxle = new ProductComponent()
            {
                Id = 3,
                Name = "Front and rear axle"
            };
            animalComponents.Add(frontAndRearAxle);

            var steeringSystem = new ProductComponent()
            {
                Id = 4,
                Name = "Vaccine"
            };
            animalComponents.Add(steeringSystem);

            var suspensionSystem = new ProductComponent()
            {
                Id = 5,
                Name = "Suspenssion system"
            };
            animalComponents.Add(suspensionSystem);


            var tyresAndBrakes = new ProductComponent()
            {
                Id = 6,
                Name = "Tyres and brakes"
            };
            animalComponents.Add(tyresAndBrakes);

            var body = new ProductComponent()
            {
                Id = 7,
                Name = "Body"
            };
            animalComponents.Add(body);

            return animalComponents;
        }
    }
}
