using Microsoft.Extensions.DependencyInjection;
using R00ster.EF;

namespace R00ster.Helpers
{   
    /// <summary>
    /// Class that responsible for service registration for the application.
    /// </summary>
    internal static class ServiceRegistrationExtension
    {
        /// <summary>
        /// Registers services, dependencies, database context for application.
        /// </summary>
        /// <param name="services">A service collection</param>
        /// <returns>Returns a service collection with registered services</returns>
        internal static IServiceCollection RegisterServices(this IServiceCollection services) 
        {
            //contexts
            services.AddDbContext<R00sterContext>();

            //windows
            services.AddSingleton<MainWindow>();

            //apps
            services.AddSingleton<App>();

            return services;
        }
    }
}
