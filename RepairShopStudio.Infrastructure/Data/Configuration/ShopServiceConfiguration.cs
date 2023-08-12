using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class ShopServiceConfiguration : IEntityTypeConfiguration<ShopService>
    {
        public void Configure(EntityTypeBuilder<ShopService> builder)
        {
            builder.HasData(CreateShopService());
        }

        List<ShopService> CreateShopService()
        {
            var shopServices = new List<ShopService>();

            var shopService = new ShopService()
            {
                Id = 1,
                Name = "Breaks check and repairs",
                Description = "Check all compnents in breaking sistem and repairing those that need it",
                Price = 65M,
                VehicleComponentId = 4
            };
            shopServices.Add(shopService);

            return shopServices;
        }
    }
}
