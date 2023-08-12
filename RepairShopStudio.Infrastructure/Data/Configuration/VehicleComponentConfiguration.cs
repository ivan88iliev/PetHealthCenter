using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class VehicleComponentConfiguration : IEntityTypeConfiguration<VehicleComponent>
    {
        public void Configure(EntityTypeBuilder<VehicleComponent> builder)
        {
            builder.HasData(CreateVehicleComponent());
        }

        List<VehicleComponent> CreateVehicleComponent()
        {
            var vehicleComponents = new List<VehicleComponent>();

            var engnie = new VehicleComponent()
            {
                Id = 1,
                Name = "Engine"
            };
            vehicleComponents.Add(engnie);

            var transmissionSystem = new VehicleComponent()
            {
                Id = 2,
                Name = "Tranmission system"
            };
            vehicleComponents.Add(transmissionSystem);

            var frontAndRearAxle = new VehicleComponent()
            {
                Id = 3,
                Name = "Front and rear axle"
            };
            vehicleComponents.Add(frontAndRearAxle);

            var steeringSystem = new VehicleComponent()
            {
                Id = 4,
                Name = "Steering system"
            };
            vehicleComponents.Add(steeringSystem);

            var suspensionSystem = new VehicleComponent()
            {
                Id = 5,
                Name = "Suspenssion system"
            };
            vehicleComponents.Add(suspensionSystem);


            var tyresAndBrakes = new VehicleComponent()
            {
                Id = 6,
                Name = "Tyres and brakes"
            };
            vehicleComponents.Add(tyresAndBrakes);

            var body = new VehicleComponent()
            {
                Id = 7,
                Name = "Body"
            };
            vehicleComponents.Add(body);

            return vehicleComponents;
        }
    }
}
