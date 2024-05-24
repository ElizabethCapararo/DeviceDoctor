using Microsoft.Extensions.DependencyInjection;
using PointOfSaleTerminalSystem;
using DeviceDoctorTerminalSystem.ViewModels;

namespace DeviceDoctorTerminalSystem.Utilities
{
    public static class ConfigurationHelper
    {
        public static void Configure(this IServiceCollection services)
        {
            services.ConfigureDatabase();
            services.ConfigureServices();
            services.ConfigureViewModels();
            services.ConfigureViews();
        }

        private static void ConfigureDatabase(this IServiceCollection services)
        {

        }

        private static void ConfigureServices(this IServiceCollection services)
        {
        }

        private static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<DeviceDoctorViewModel>();
        }

        private static void ConfigureViews(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
        }
    }
}
