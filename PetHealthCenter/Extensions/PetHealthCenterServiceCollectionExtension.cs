using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetHealthCenter.Core.Contracts;
using PetHealthCenter.Core.Exceptions;
using PetHealthCenter.Core.Services;
using PetHealthCenter.Infrastructure.Data.Common;
using PetHealthCenter.Infrastructure.Data.Common.User;

namespace PetHealthCenter.Extensions
{
    public static class PetHealthCenterServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPartService, PartService>();
            services.AddScoped<IHealthServiceService, HealthServiceService>();
            services.AddScoped<IGuard, Guard>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOperatingCardService, OperatingCardService>();
            services.AddScoped<IPetService, PetService>();
            return services;
        }
    }
}
