using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasData(CreatePart());
        }

        List<Part> CreatePart()
        {
            var parts = new List<Part>();

            var part = new Part()
            {
                Id = 1,
                Name = "Sport Brake Disc for MERCEDES-BENZ M-KLASSE (W164)",
                ImageUrl = "https://www.zimmermann-bremsentechnik.eu/images/product_images/info_images/400_3649_52.jpg",
                Stock = 4,
                Manufacturer = "Zimmerman",
                OriginalMpn = "400.3649.52",
                Description = "Front",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                VehicleComponentId = 2
            };
            parts.Add(part);

            return parts;
        }
    }
}
