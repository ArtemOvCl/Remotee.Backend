
namespace RemoteAccess.Extensions
{
    public static class ControllerConfiguration
    {
        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        public static void UseCustomControllers(this IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
