using Microsoft.EntityFrameworkCore;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Exceptions;
using PetHealthCenter.Core.Services;
using PetHealthCenter.Infrastructure.Data;
using PetHealthCenter.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PetHealthCenterApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }

        public static IServiceCollection AddPetHealthDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
