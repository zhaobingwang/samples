using AbpSample.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpSample
{
    [DependsOn(
        typeof(AbpSampleEntityFrameworkCoreTestModule)
        )]
    public class AbpSampleDomainTestModule : AbpModule
    {

    }
}