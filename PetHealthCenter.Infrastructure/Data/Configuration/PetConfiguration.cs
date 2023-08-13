using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHealthCenter.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHealthCenter.Infrastructure.Data.Configuration
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.HasData(CreatePet());
        }

        List<Pet> CreatePet()
        {
            var animals = new List<Pet>();

            var animal = new Pet()
            {
                Id = 1,
                Make = "Labrador",
                Model = "American",
                IdentificationNUmber = "B5466HA",
                FIrstRegistration = DateTime.Parse("2013-06-23"),
                SpecieTypeId = 2,
                Weight = 272,
                PetNumber = "12312324125",
                CustomerId = 1
            };

            animals.Add(animal);

            var animal2 = new Pet()
            {
                Id = 4,
                Make = "Husky",
                Model = "Siberian",
                IdentificationNUmber = "B5432PA",
                FIrstRegistration = DateTime.Parse("2013-06-24"),
                SpecieTypeId = 1,
                Weight = 156,
                PetNumber = "12312324642",
                CustomerId = 2
            };

            animals.Add(animal2);

            return animals;
        }
    }
}
