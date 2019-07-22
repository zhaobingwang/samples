using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Sample.NetCore.HostBackgroundTasks.Tasks;
using System.Threading;
using System.Runtime.Loader;

namespace Sample.NetCore.HostBackgroundTasks
{
    class Program
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public static async Task Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            AssemblyLoadContext.Default.Unloading += Default_Unloading;

            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);

            var builder = new HostBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddSingleton<IHostedService, TestService>();
                //services.AddHostedService<TestConsumerService>();
                services.AddLogging();
                //services.AddHostedService<LifetimeEventsHostedService>();

                var serviceProvider = services.BuildServiceProvider();
            })
            .ConfigureLogging((hostContext, configLogging) =>
            {
                //configLogging.AddConsole();
                configLogging.SetMinimumLevel(LogLevel.Trace);
                configLogging.AddNLog();
                //configLogging.AddDebug();
            });
            await builder.RunConsoleAsync();
            //_closing.WaitOne();
        }

        private static void Default_Unloading(AssemblyLoadContext obj)
        {
            Console.WriteLine("unload");
            logger.Info("unload");
        }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            // docker stop时，可在此处做一些清理工作。
            //IServiceProvider serviceProvider = new ServiceCollection().BuildServiceProvider();
            //var testService = serviceProvider.GetService<IHostedService>();
            //testService.StopAsync(new CancellationToken()).Wait();

            Console.WriteLine("process exit");
            logger.Info("process exit");
        }

        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exit");
            logger.Info("Exit");
            _closing.Set();
        }
    }
}
