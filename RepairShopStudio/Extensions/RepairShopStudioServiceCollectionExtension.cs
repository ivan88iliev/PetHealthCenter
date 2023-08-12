using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RepairShopStudio.Core.Contracts;
using RepairShopStudio.Core.Exceptions;
using RepairShopStudio.Core.Services;
using RepairShopStudio.Infrastructure.Data.Common;
using RepairShopStudio.Infrastructure.Data.Common.User;

namespace RepairShopStudio.Extensions
{
    public static class RepairShopStudioServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IShopServiceService, ShopServiceService>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOperatingCardService, OperatingCardService>();
            services.AddScoped<IVehicleService, VehicleService>();
            return services;
        }
    }
}
