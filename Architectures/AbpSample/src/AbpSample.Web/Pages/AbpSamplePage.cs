using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using AbpSample.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpSample.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits AbpSample.Web.Pages.AbpSamplePage
     */
    public abstract class AbpSamplePage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<AbpSampleResource> L { get; set; }
    }
}
