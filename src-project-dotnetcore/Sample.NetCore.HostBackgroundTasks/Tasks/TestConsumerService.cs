using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.NetCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.NetCore.HostBackgroundTasks.Tasks
{
    public class TestConsumerService : BackgroundService//IHostedService, IDisposable
    {
        private readonly ILogger<TestConsumerService> _logger;
        TestConsumer testConsumer = null;
        public TestConsumerService(ILogger<TestConsumerService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            testConsumer = new TestConsumer(_logger);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogDebug($"TestService background task is starting.");
            stoppingToken.Register(TaskStop);
            if (!stoppingToken.IsCancellationRequested)
            {
                testConsumer.StartConsume();
            }
            else
            {
                testConsumer.StopConsume();
            }
            return Task.CompletedTask;
        }

        private void TaskStop()
        {
            _logger.LogDebug($"TestService background task is stopping.");
        }
        //public Task StartAsync(CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation($"{nameof(TestConsumerService)} starting...");

        //    if (!cancellationToken.IsCancellationRequested && testConsumer != null)
        //    {
        //        testConsumer.StartConsume();
        //    }
        //    return Task.CompletedTask;
        //}

        //public Task StopAsync(CancellationToken cancellationToken)
        //{
        //    _logger.LogInformation($"{nameof(TestConsumerService)} stoping...");
        //    if (testConsumer != null)
        //        testConsumer.StopConsume();
        //    return Task.CompletedTask;
        //}
        //public void Dispose()
        //{
        //}

    }
    public class TestConsumer : Consumer
    {
        public const string QUEUE_NAME = "";
        ILogger<TestConsumerService> _logger;
        public TestConsumer(ILogger<TestConsumerService> logger) : base("amqp://admin:admin@127.0.0.1:5672", QUEUE_NAME)
        {
            _logger = logger;
        }
        public override bool MessageConsume(string message)
        {
            _logger.LogInformation(message);
            return true;
        }
    }
}
