using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AspNetBoilerplate.Controllers
{
    public abstract class AspNetBoilerplateControllerBase: AbpController
    {
        protected AspNetBoilerplateControllerBase()
        {
            LocalizationSourceName = AspNetBoilerplateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
