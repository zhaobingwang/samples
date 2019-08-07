using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sample.NetCore.Web.Models;
using Sample.NetCore.Infrastructure;
using Sample.NetCore.ApplicationCore.Interfaces;
using Microsoft.Extensions.Options;

namespace Sample.NetCore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTime _dateTime;
        //public IConfiguration Configuration { get; }
        private readonly Settings _settings;
        public HomeController(IOptions<Settings> settings, IDateTime dateTime)
        {
            _settings = settings.Value;
            _dateTime = dateTime;
        }
        public IActionResult Index()
        {
            ViewData["AppName"] = _settings.AppName;
            ViewData["Others"] = _settings.Others;

            // say hi
            var serverTime = _dateTime.Now;
            if (serverTime.Hour < 12)
                ViewData["SayHi"] = "早上好";
            else if (serverTime.Hour < 17)
                ViewData["SayHi"] = "下午好";
            else
                ViewData["SayHi"] = "晚上好";

            // 视图注入-填充查找数据
            var profile = new ProfileViewModel()
            {
                Name = "张三",
                FavColor = "蓝",
                Gender = "男",
                Province = new ProvinceViewModel("浙江", "Zhejiang")
            };
            return View(profile);
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Index", "Home", new { id = 1 });
            return Content(url);
        }

        public IActionResult About([FromServices] IDateTime dateTime)
        {
            //return View("Views/Home/About.cshtml");
            //return View("Privacy");
            ViewData["Now"] = $"当前服务器时间：{dateTime.Now}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
