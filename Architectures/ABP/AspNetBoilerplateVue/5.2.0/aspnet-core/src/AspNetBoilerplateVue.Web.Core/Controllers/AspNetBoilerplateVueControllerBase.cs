using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AspNetBoilerplateVue.Controllers
{
    public abstract class AspNetBoilerplateVueControllerBase: AbpController
    {
        protected AspNetBoilerplateVueControllerBase()
        {
            LocalizationSourceName = AspNetBoilerplateVueConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
