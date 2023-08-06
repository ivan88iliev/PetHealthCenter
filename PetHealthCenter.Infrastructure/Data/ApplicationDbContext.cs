using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Infrastructure.Data.Models;
using PetHealthCenter.Infrastructure.Data.Models.Account;

namespace PetHealthCenter.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SpeciesType> SpeciesTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<HealthService> HealthServices { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<MedicalComponent> MedicalComponentс { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<OperatingCard> OperatingCards { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SupplierMedicalComponent>()
                .HasKey(x => new { x.SupplierId, x.ProductId });

            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
