using Microsoft.EntityFrameworkCore;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Exceptions;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data;
using RepairShopStudio.Infrastructure.Data.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class RepairShopStudioApiServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStatisticsService, StatisticsService>();
            services.AddScoped<IGuard, Guard>();

            return services;
        }

        public static IServiceCollection AddRepairShopDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
