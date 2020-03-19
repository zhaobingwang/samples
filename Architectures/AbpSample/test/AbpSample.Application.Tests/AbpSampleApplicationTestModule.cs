using Volo.Abp.Modularity;

namespace AbpSample
{
    [DependsOn(
        typeof(AbpSampleApplicationModule),
        typeof(AbpSampleDomainTestModule)
        )]
    public class AbpSampleApplicationTestModule : AbpModule
    {

    }
}