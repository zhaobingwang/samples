using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace AbpSample.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(AbpSampleHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AbpSampleConsoleApiClientModule : AbpModule
    {
        
    }
}
