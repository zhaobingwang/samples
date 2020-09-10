using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.Server;
using Hangfire.SqlServer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HangfireAspNetCoreDemo.BackgroundTask
{
    public class RecurringJobsService : BackgroundService
    {
        private readonly IBackgroundJobClient _backgroundJob;
        private readonly IRecurringJobManager _recurringJob;
        private readonly ILogger<RecurringJobsService> _logger;
        public RecurringJobsService(IBackgroundJobClient backgroundJob, IRecurringJobManager recurringJob, ILogger<RecurringJobsService> logger)
        {
            _backgroundJob = backgroundJob;
            _recurringJob = recurringJob;
            _logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _recurringJob.AddOrUpdate("A10001", () => Print(), "*/5 * * * * ?", TimeZoneInfo.Local);
            }
            catch (Exception ex)
            {
                _logger.LogError("创建周期性作业时发生异常", ex);
            }

            return Task.CompletedTask;
        }

        public void Print()
        {
            _logger.LogInformation(DateTime.Now.ToString("yyyy年MM月dd日 HH分mm分ss秒"));
        }
    }
}
