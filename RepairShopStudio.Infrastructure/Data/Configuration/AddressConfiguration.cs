using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure (EntityTypeBuilder<Address> builder)
        {
            builder.HasData(CreateAddresses());
        }

        private List<Address> CreateAddresses ()
        {
            var addresses = new List<Address> ();

            var address = new Address()
            {
                Id = 1,
                AddressText = "Tsar Osvobodiltel str. 98",
                TownName = "Varna",
                ZipCode = "9000"
            };

            addresses.Add(address);

            var address1 = new Address()
            {
                Id = 2,
                AddressText = "Slivnitsa blv. 108",
                TownName = "Varna",
                ZipCode = "9000"
            };

            addresses.Add(address1);

            return addresses;
        }
    }
}
