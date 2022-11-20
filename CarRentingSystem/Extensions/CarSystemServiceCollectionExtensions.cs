using CarRentingSystem.Core.Contracts;
using CarRentingSystem.Core.Services;
using HouseRentingSystem.Infrastructure.Data.Common;

namespace CarRentingSystem.Extensions
{
    public static class CarSystemServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<ICarService, CarService>();

            return services;
        }
    }
}
