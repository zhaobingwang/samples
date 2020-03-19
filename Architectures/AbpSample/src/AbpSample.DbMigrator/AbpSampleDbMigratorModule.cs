using AbpSample.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpSample.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpSampleEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpSampleApplicationContractsModule)
        )]
    public class AbpSampleDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
