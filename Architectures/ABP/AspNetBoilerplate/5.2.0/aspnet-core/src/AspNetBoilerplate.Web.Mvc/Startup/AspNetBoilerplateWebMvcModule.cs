using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerplate.Configuration;

namespace AspNetBoilerplate.Web.Startup
{
    [DependsOn(typeof(AspNetBoilerplateWebCoreModule))]
    public class AspNetBoilerplateWebMvcModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetBoilerplateWebMvcModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AspNetBoilerplateNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerplateWebMvcModule).GetAssembly());
        }
    }
}
