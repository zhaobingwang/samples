using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Sample.NetCore.HostBackgroundTasks.Tasks;
using System;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.NetCore.HostBackgroundTasks
{
    class Program
    {
        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IHostedService, TestService>();
                //services.AddHostedService<TestConsumerService>();
                services.AddLogging();
                services.AddHostedService<LifetimeEventsHostedService>();

                var serviceProvider = services.BuildServiceProvider();
            })
            .ConfigureLogging((hostContext, configLogging) =>
            {
                //configLogging.AddConsole();
                configLogging.SetMinimumLevel(LogLevel.Trace);
                configLogging.AddNLog();

                //configLogging.AddDebug();
            })
            //.UseConsoleLifetime()
            .Build();
            await builder.RunAsync();
        }
    }
}
