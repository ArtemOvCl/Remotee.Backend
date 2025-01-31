using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RemoteAccess.Hubs;

namespace RemoteAccess.Extensions
{
    public static class HubConfiguration
    {
        public static void AddCustomHubs(this WebApplication app)
        {

            app.MapHub<SessionHub>("/sessionHub");
        }
    }
}
