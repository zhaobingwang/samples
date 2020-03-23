using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerplate.Authorization;

namespace AspNetBoilerplate
{
    [DependsOn(
        typeof(AspNetBoilerplateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AspNetBoilerplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AspNetBoilerplateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AspNetBoilerplateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
