using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.NetCore.HostBackgroundTasks.Tasks
{
    public class TestService : IHostedService//BackgroundService//IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly ILogger<TestService> _logger;
        public TestService(ILogger<TestService> logger)
        {
            _logger = logger;
        }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    _logger.LogDebug($"TestService background task is starting.");
        //    stoppingToken.Register(TaskStop);
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        DoWork(null);

        //        await Task.Delay(1000, stoppingToken);
        //    }
        //}
        private void TaskStop()
        {
            _logger.LogDebug($"TestService background task is stopping.");
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(TestService)} starting...");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(TestService)} stoping...");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        private void DoWork(object state)
        {
            _logger.LogInformation(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
        }

        //public void Dispose()
        //{
        //    _timer?.Dispose();
        //}
    }
}
