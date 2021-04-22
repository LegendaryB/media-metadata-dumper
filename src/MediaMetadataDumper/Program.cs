using MediaMetadataDumper.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System;
using System.Threading.Tasks;

namespace MediaMetadataDumper
{
    class Program
    {
        private static IConfiguration Configuration { get; set; }

        public static async Task Main()
        {
            var host = CreateHostBuilder()
                .Build();

            await RunAppAsync(host.Services);
        }

        private static async Task RunAppAsync(IServiceProvider serviceProvider)
        {
            var app = serviceProvider
                .GetRequiredService<App>();

            await app.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((ctx, services) =>
                {
                    Configuration = ctx.Configuration;
                    ConfigureServices(services);
                });
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var options = new AppOptions();
            Configuration.Bind(options);

            services.AddSingleton(options);

            services.AddTransient<App>();
        }
    }
}
