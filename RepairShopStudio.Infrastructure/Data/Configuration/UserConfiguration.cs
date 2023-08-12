using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepairShopStudio.Infrastructure.Data.Models.User;

namespace RepairShopStudio.Infrastructure.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = Guid.Parse("8bc5851a-9b57-4d66-99ae-4bfd11f26bd2"),
                FirstName = "Ivan",
                LastName = "Ivanov",
                UserName = "General_Manager",
                NormalizedUserName = "GENERAL_MANAGER",
                Email = "manager_repair_shop@mail.com",
                NormalizedEmail = "MANAGER_REPAIR_SHOP@MAIL.COM",
                SecurityStamp = Guid.Parse("70c7ac29-fc79-45e7-9d29-b922b7cd7f1e").ToString()
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Manager123!");

            users.Add(user);

            var user1 = new ApplicationUser()
            {
                Id= Guid.Parse("59bff60d-d8d8-4ca8-9da9-48149761e9db"),
                FirstName = "Petar",
                LastName = "Petrov",
                UserName = "Mechanic",
                NormalizedUserName = "MECHANIC",
                Email = "mechanic_repair_shop@mail.com",
                NormalizedEmail = "MECHANIC_REPAIR_SHOP@MAIL.COM",
                SecurityStamp = Guid.Parse("5755db6a-132e-475d-93b6-d6c2f46f6fad").ToString()
            };

            user1.PasswordHash =
                 hasher.HashPassword(user, "Mechanic123!");

            users.Add(user1);

            var user2 = new ApplicationUser()
            {
                Id = Guid.Parse("4d3bb951-2772-4ae8-b6bb-eb4e80426b0e"),
                FirstName = "Georgi",
                LastName = "Georgiev",
                UserName = "Service_Adviser",
                NormalizedUserName = "SERVICE_ADVISER",
                Email = "adviser_repair_shop@mail.com",
                NormalizedEmail = "ADVISER_REPAIR_SHOP@MAIL.COM",
                SecurityStamp = Guid.Parse("780e294a-90d6-4b9f-987f-a958b729a0b3").ToString()
            };

            user2.PasswordHash =
                 hasher.HashPassword(user2, "Adviser123!");

            users.Add(user2);

            return users;
        }
    }
}
