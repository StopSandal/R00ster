using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using R00ster.EF;
using R00ster.Services.Interfaces.DatabaseSavers;
using R00ster.Services.Interfaces.FileReaders;
using R00ster.Services.Interfaces.MainWindowServices;
using R00ster.Services.Interfaces.Other;
using R00ster.Services.Realization.DatabaseSavers;
using R00ster.Services.Realization.FileReaders;
using R00ster.Services.Realization.MainWindowServices;
using R00ster.Services.Realization.Other;
using R00ster.ViewModels;

namespace R00ster.Helpers
{
    /// <summary>
    /// Class that responsible for service registration for the application.
    /// </summary>
    internal static class ServiceRegistrationExtension
    {
        private const string DatabaseConnectionPath = "DefaultConnection";

        /// <summary>
        /// Registers services, dependencies, database context for application.
        /// </summary>
        /// <param name="services">A service collection</param>
        /// <returns>Returns a service collection with registered services</returns>
        internal static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //services
            services.AddScoped<IMainWindowService, MainWindowService>();
            services.AddScoped<IJokesExcelReader, JokesExcelReader>();
            services.AddScoped<IJokeDatabaseSaver, JokeDatabaseSaver>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //contexts
            services.AddDbContext<R00sterContext>(options =>
            {
                options.UseSqlServer(Program.Config.GetConnectionString(DatabaseConnectionPath));
            });

            //windows
            services.AddSingleton<MainWindow>();

            // View Models
            services.AddSingleton<MainWindowVM>();

            //apps
            services.AddSingleton<App>();

            return services;
        }
    }
}
