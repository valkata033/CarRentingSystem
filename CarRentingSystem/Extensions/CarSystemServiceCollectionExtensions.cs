using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Contracts.Admin;
using CarRentingSystem.Core.Services;
using CarRentingSystem.Core.Services.Admin;
using CarRentingSystem.Infrastructure.Data.Common;

namespace CarRentingSystem.Extensions
{
    public static class CarSystemServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IDealerService, DealerService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
