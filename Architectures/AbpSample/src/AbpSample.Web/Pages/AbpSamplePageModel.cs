using AbpSample.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace AbpSample.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AbpSamplePageModel : AbpPageModel
    {
        protected AbpSamplePageModel()
        {
            LocalizationResourceType = typeof(AbpSampleResource);
        }
    }
}