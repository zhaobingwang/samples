using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpSample.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpSampleEntityFrameworkCoreModule)
        )]
    public class AbpSampleEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpSampleMigrationsDbContext>();
        }
    }
}
