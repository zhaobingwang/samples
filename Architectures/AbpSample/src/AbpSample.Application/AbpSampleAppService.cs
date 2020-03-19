using System;
using System.Collections.Generic;
using System.Text;
using AbpSample.Localization;
using Volo.Abp.Application.Services;

namespace AbpSample
{
    /* Inherit your application services from this class.
     */
    public abstract class AbpSampleAppService : ApplicationService
    {
        protected AbpSampleAppService()
        {
            LocalizationResource = typeof(AbpSampleResource);
        }
    }
}
