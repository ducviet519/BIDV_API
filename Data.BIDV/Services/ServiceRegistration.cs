using Data.BIDV.Services.Interfaces;
using Data.BIDV.Services.Repositories;
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
            services.AddTransient<IConnectAPI_VBNBClient, ConnectAPI_VBNBClient>();
        }
    }
}
