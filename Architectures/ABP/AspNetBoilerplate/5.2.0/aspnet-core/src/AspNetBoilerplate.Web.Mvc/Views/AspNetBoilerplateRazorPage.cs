using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace AspNetBoilerplate.Web.Views
{
    public abstract class AspNetBoilerplateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AspNetBoilerplateRazorPage()
        {
            LocalizationSourceName = AspNetBoilerplateConsts.LocalizationSourceName;
        }
    }
}
