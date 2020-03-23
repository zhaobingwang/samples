using Abp.AspNetCore.Mvc.ViewComponents;

namespace AspNetBoilerplate.Web.Views
{
    public abstract class AspNetBoilerplateViewComponent : AbpViewComponent
    {
        protected AspNetBoilerplateViewComponent()
        {
            LocalizationSourceName = AspNetBoilerplateConsts.LocalizationSourceName;
        }
    }
}
