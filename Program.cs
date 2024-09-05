using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using R00ster.Helpers;

namespace R00ster
{
    /// <summary>
    /// Initial application start class. Also starts background proccess.
    /// </summary>
    internal class Program
    {
        private const string SettingsFilePath = "appsettings.json";
        public static IConfiguration Config { get; private set; }

        [STAThread]
        public static void Main(string[] args)
        {
            Config = new ConfigurationBuilder()
                .AddJsonFile(SettingsFilePath, optional: false, reloadOnChange: true)
                .Build();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.RegisterServices();
                    services.RegisterBackgroundServices();
                })
                .Build();


            var backgroundService = host.Services.GetRequiredService<IHostedService>();
            backgroundService.StartAsync(default).GetAwaiter().GetResult();

            if (!args.Contains("--background"))
            {
                var app = host.Services.GetService<App>();

                app?.Run();
            }

            host.Run();
        }
    }
}
