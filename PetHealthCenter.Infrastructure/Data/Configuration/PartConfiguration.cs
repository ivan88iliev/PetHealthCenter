using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetHealthCenter.Infrastructure.Data.Models;

namespace PetHealthCenter.Infrastructure.Data.Configuration
{
    internal class PartConfiguration : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
        {
            builder.HasData(CreatePart());
        }

        List<Part> CreatePart()
        {
            varmedical products= new List<Part>();

            var part = new Part()
            {
                Id = 1,
                Name = "Cosequin Maximum Strength Tablets",
                ImageUrl = "https://s.turbifycdn.com/aah/healthypetscom/2-pack-cosequin-ds-plus-msm-chewable-tablets-500-count-130.jpg",
                Stock = 4,
                Manufacturer = "Cosequin",
                OriginalMpn = "CHEWDS250-MSM-2PK",
                Description = "Cosequin Maximum Strength Plus MSM Joint Supplement for Dogs, 500 Chewable Tablets",
                PriceBuy = 99.98M,
                PriceSell = 114.56M,
                ProductComponentId = 2
            };
            medProducts.Add(part);

            return medProducts;
        }
    }
}
