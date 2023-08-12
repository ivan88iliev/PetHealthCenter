using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class OperatingCardConfiguration : IEntityTypeConfiguration<OperatingCard>
    {
        public void Configure(EntityTypeBuilder<OperatingCard> builder)
        {
            builder.HasData(CreateOperatingCard());
        }

        List<OperatingCard> CreateOperatingCard()
        {
            var operatingCards = new List<OperatingCard>();

            var operatingCard = new OperatingCard()
            {
                Id = 1,
                Date = DateTime.Now.Date,
                DocumentNumber = $"B5466HA/06.12.2022",
                CustomerId = 1,
                ApplicationUserId = Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                PartId = 1,
                ServiceId = 1,
                VehicleId = 1,
            };

            operatingCards.Add(operatingCard);

            return operatingCards;
        }
    }
}
