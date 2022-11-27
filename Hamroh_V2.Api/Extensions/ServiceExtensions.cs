using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Data.Repositories;
using Hamroh_V2.Service.Interfaces;
using Hamroh_V2.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Hamroh_V2.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // services
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDriverAdService, DriverAdService>();
            services.AddScoped<IDriverService, DriverService>();
            services.AddScoped<IClientAdService, ClientAdService>();
        }
    }
}
 