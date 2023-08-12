using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(CreateOrder());
        }

        List<Order> CreateOrder()
        {
            var orders = new List<Order>();

            var order = new Order()
            {
                Id = 1,
                IssueDate = DateTime.Now.Date,
                Number = $"0001/{DateTime.Now.Date}",
                Note = "To arrive today",
                SupplierId = 1
            };
            orders.Add(order);

            return orders;
        }
    }
}
