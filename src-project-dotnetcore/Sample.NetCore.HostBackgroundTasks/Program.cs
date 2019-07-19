using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Sample.NetCore.HostBackgroundTasks
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<TestService>();
                services.AddLogging();
            })
            .ConfigureLogging((hostContext, configLogging) =>
            {
                //configLogging.AddConsole();
                configLogging.SetMinimumLevel(LogLevel.Trace);
                configLogging.AddNLog();
                //configLogging.AddDebug();
            })
            .RunConsoleAsync();
        }
    }
}
