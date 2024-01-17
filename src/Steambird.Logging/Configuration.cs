using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Steambird.Logging
{
    public static class Configuration
    {
        public static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File($"{Environment.CurrentDirectory}/logs/{DateTimeOffset.Now:yyyy-MM-dd_HH-mm-ss}.log")
                .CreateLogger();
        }

        public static IHostBuilder ConfigureLogging(this ConfigureHostBuilder hostBuilder)
        {
            return hostBuilder.UseSerilog();
        }

        public static IApplicationBuilder RequestLogging(this WebApplication app)
        {
            return app.UseSerilogRequestLogging();
        }
    }
}
