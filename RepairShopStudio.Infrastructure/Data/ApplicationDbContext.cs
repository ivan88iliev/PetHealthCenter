using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Infrastructure.Data.Configuration;
using RepairShopStudio.Infrastructure.Data.Models;
using RepairShopStudio.Infrastructure.Data.Models.User;
using System.Reflection.Emit;

namespace RepairShopStudio.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EngineType> EngineTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ShopService> ShopServices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleComponent> VehicleComponents { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<OperatingCard> OperatingCards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new JobTItleConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
            builder.ApplyConfiguration(new EngineTypeConfiguration());
            builder.ApplyConfiguration(new ShopServiceConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new VehicleComponentConfiguration());
            builder.ApplyConfiguration(new PartConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OperatingCardConfiguration());

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(40)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Entity<OperatingCard>()
                .Property(u => u.DocumentNumber)
                .IsRequired(false);

            builder.Entity<ApplicationUser>()
                .Property(u => u.IsActive)
                .HasDefaultValue(true);

            builder.Entity<OperatingCard>()
                .Property(oc => oc.IsActive)
                .HasDefaultValue(true);

            builder.Entity<OperatingCard>()
                .Property(oc => oc.IsActive)
                .HasDefaultValue(true);

            builder.Entity<SupplierSparePart>()
                .HasKey(x => new { x.SupplierId, x.PartId });

            builder.Entity<OperatingCardParts>()
                .HasKey(x => new { x.OperatingCardId, x.PartId });

            builder.Entity<OperatingCardShopService>()
               .HasKey(x => new { x.OperatingCardId, x.ShopServiceId });

            builder.Entity<Customer>()
                .Property(p => p.AddressId)
                .IsRequired(false);

            builder.Entity<Customer>()
                .Property(p => p.ResponsiblePerson)
                .IsRequired(false);

            builder.Entity<Customer>()
                .Property(p => p.Uic)
                .IsRequired(false);

            
        }
    }
}
