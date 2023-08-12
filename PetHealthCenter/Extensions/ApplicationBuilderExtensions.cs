using Microsoft.AspNetCore.Identity;
using PetHealthCenter.Infrastructure.Data.Models.User;
using static PetHealthCenter.Common.Constants.RoleConstants;
using static PetHealthCenter.Common.Constants.AdminConstants;

namespace PetHealthCenter.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedRolesInDatabase(this IApplicationBuilder app)
        {

            using var serviceScope = app.ApplicationServices.CreateScope();
            var serviceProvider = serviceScope.ServiceProvider;

            SeedDoctor(serviceProvider);
            SeedServiceAdivser(serviceProvider);
            SeedAdmin(serviceProvider);


            return app;
        }

        private static void SeedAdmin(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<ApplicationRole>>();

            Task.
                Run(async () =>
                {
                    if (!await roleManager.RoleExistsAsync(Administrator))
                    {
                        await roleManager.CreateAsync(new ApplicationRole(Administrator));
                    }

                    var user = await userManager.FindByEmailAsync(AdminEmail);
                    await userManager.AddToRolesAsync(user, new string[] { Administrator, ServiceAdviser, Doctor });
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedServiceAdivser(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<ApplicationRole>>();

            Task.
                Run(async () =>
                {
                    if (!await roleManager.RoleExistsAsync(ServiceAdviser))
                    {
                        await roleManager.CreateAsync(new ApplicationRole(ServiceAdviser));
                    }

                    string email2 = "adviser_pet_health@mail.com";
                    var user2 = await userManager.FindByEmailAsync(email2);
                    await userManager.AddToRolesAsync(user2, new string[] { ServiceAdviser, Doctor });
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedDoctor(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<ApplicationRole>>();

            Task.
                Run(async () =>
                {
                    if (!await roleManager.RoleExistsAsync(Doctor))
                    {
                        await roleManager.CreateAsync(new ApplicationRole(Doctor));
                    }

                    string email3 = "doctor_pet_health@mail.com";
                    var user3 = await userManager.FindByEmailAsync(email3);
                    await userManager.AddToRolesAsync(user3, new string[] { Doctor });

                })
                .GetAwaiter()
                .GetResult();
        }
    }
}