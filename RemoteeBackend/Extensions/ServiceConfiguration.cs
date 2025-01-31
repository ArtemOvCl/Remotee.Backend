using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using RemoteAccess.Hubs;
using RemoteAccess.Services;

namespace RemoteAccess.Extensions
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddSignalR();

            services.AddSingleton<SessionService>();
            services.AddSingleton<BatteryService>();

            return services;
        }
    }
}
