using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerplate.Configuration;

namespace AspNetBoilerplate.Web.Host.Startup
{
    [DependsOn(
       typeof(AspNetBoilerplateWebCoreModule))]
    public class AspNetBoilerplateWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AspNetBoilerplateWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AspNetBoilerplateWebHostModule).GetAssembly());
        }
    }
}
