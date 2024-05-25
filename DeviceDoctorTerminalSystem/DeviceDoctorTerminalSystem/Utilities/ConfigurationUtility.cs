using Microsoft.Extensions.DependencyInjection;
using PointOfSaleTerminalSystem;
using DeviceDoctorTerminalSystem.ViewModels;
using DeviceDoctorTerminalSystem.Database;
using DeviceDoctorTerminalSystem.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DeviceDoctorTerminalSystem.Utilities
{
    public static class ConfigurationUtility
    {
        public static void Configure(this IServiceCollection services)
        {
            services.ConfigureAutoMapper();
            services.ConfigureDatabase();
            services.ConfigureServices();
            services.ConfigureViewModels();
            services.ConfigureViews();
        }

        private static void ConfigureAutoMapper(this IServiceCollection services)
        {
            
        }

        private static void ConfigureDatabase(this IServiceCollection services)
        {
            services.AddDbContext<IDocDbContext, DocDbContext>();
        }

        private static void ConfigureServices(this IServiceCollection services)
        {
            services.AddDbContext<IDocDbContext, DocDbContext>();

            services.AddSingleton<RepairService>();
            services.AddSingleton<CustomerService>();
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
