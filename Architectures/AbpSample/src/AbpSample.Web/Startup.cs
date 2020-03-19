using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace AbpSample.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AbpSampleWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
