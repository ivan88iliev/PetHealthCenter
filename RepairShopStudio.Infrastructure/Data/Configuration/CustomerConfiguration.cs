using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(CreateCustomer());
        }

        private List<Customer> CreateCustomer()
        {
            var customers = new List<Customer>();

            var customer = new Customer()
            {
                Id = 1,
                Name = "Ivanov.Inc",
                PhoneNumber = "099999999",
                Email = "ivan.ivanov@abv.bg",
                IsCorporate = true,
                Uic = "1234543421234",
                AddressId = 1,
                ResponsiblePerson = "Ivan Ivanov",
                //VehicleId = 1,
            };

            customers.Add(customer);

            var customer2 = new Customer()
            {
                Id = 2,
                Name = "Boris Borisov",
                PhoneNumber = "0898888888",
                Email = "boris.borisov@abv.bg",
                IsCorporate = false,
                AddressId= 2,
                //VehicleId = 4
            };

            customers.Add(customer2);

            return customers;
        }
    }
}
