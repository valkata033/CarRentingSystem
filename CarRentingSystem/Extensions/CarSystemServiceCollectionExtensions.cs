using HouseRentingSystem.Infrastructure.Data.Common;

namespace CarRentingSystem.Extensions
{
    public static class CarSystemServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationsServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
