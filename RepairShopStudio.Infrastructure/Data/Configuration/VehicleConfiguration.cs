using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(CreateVehicle());
        }

        List<Vehicle> CreateVehicle()
        {
            var vehicles = new List<Vehicle>();

            var vehicle = new Vehicle()
            {
                Id = 1,
                Make = "Mercedes-Benz",
                Model = "W164 350",
                LicensePLate = "B5466HA",
                FIrstRegistration = DateTime.Parse("2013-06-23"),
                EngineTypeId = 2,
                Power = 272,
                VinNumber = "12312324125",
                CustomerId = 1
            };

            vehicles.Add(vehicle);

            var vehicle2 = new Vehicle()
            {
                Id = 4,
                Make = "BMW",
                Model = "E320",
                LicensePLate = "B5432PA",
                FIrstRegistration = DateTime.Parse("2013-06-24"),
                EngineTypeId = 1,
                Power = 156,
                VinNumber = "12312324642",
                CustomerId = 2
            };

            vehicles.Add(vehicle2);

            return vehicles;
        }
    }
}
