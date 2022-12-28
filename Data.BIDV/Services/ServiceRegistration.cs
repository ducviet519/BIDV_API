using DataBIDV.Services.Interfaces;
using DataBIDV.Services.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataBIDV.Services
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IConnectAPI_BIDVClient, ConnectAPI_BIDVClient>();
        }
    }
}
