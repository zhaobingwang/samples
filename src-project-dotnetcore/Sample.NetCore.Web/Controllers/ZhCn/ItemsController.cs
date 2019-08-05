using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Sample.NetCore.Web.Controllers.ZhCn
{
    public class ItemsController : Controller
    {
        [CountrySpecific("ZH-CN")]
        public IActionResult Index()
        {
            return View();
        }
    }
}