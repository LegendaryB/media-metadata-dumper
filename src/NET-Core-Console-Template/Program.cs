using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using NET_Core_Console_Template.Options;

using System.Threading.Tasks;

namespace NET_Core_Console_Template
{
    class Program
    {
        private static IConfiguration Configuration { get; set; }

        public static async Task Main()
        {
            var host = CreateHostBuilder()
                .Build();

            var app = host
                .Services
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
            // Add your services

            services.Configure<MyOptions>(
                Configuration.GetSection(MyOptions.SectionName));

            services.AddTransient<App>();
        }
    }
}
