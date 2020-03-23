using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerplateVue.Configuration;

namespace AspNetBoilerplateVue.Web.Host.Startup
{
    [DependsOn(
       typeof(AspNetBoilerplateVueWebCoreModule))]
    public class AspNetBoilerplateVueWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetBoilerplateVueWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerplateVueWebHostModule).GetAssembly());
        }
    }
}
