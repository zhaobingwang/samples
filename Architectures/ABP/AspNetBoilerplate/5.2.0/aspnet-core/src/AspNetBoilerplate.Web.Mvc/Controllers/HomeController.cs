using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using AspNetBoilerplate.Controllers;

namespace AspNetBoilerplate.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : AspNetBoilerplateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
