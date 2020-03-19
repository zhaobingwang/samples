using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace AbpSample
{
    public class AbpSampleWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AbpSampleWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}