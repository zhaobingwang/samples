using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace AbpSample.Web
{
    [Dependency(ReplaceServices = true)]
    public class AbpSampleBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpSample";
    }
}
