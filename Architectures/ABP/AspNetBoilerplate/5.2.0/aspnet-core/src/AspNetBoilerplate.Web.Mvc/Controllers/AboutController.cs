using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AspNetBoilerplate.Controllers;

namespace AspNetBoilerplate.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : AspNetBoilerplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
