using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasData(CreateSupplier());
        }

        List<Supplier> CreateSupplier()
        {
            var suppliers = new List<Supplier>();

            var supplier = new Supplier()
            {
                Id = 1,
                Name = "Garvan",
                CompanyName = "Garvan EOOD",
                Uic = "123456789876",
                PhoneNumber = "0898888888",
                Email = "garvan@abv.bg",
                AddressId = 2
            };

            suppliers.Add(supplier);

            return suppliers;
        }
    }
}
