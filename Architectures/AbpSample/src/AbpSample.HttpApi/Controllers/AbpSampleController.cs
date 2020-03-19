using AbpSample.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpSample.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class AbpSampleController : AbpController
    {
        protected AbpSampleController()
        {
            LocalizationResource = typeof(AbpSampleResource);
        }
    }
}