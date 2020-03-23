using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AspNetBoilerplateVue.Authorization;

namespace AspNetBoilerplateVue
{
    [DependsOn(
        typeof(AspNetBoilerplateVueCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AspNetBoilerplateVueApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AspNetBoilerplateVueAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AspNetBoilerplateVueApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
