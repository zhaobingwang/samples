using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HangfireAspNetCoreDemo.Models;
using Hangfire;

namespace HangfireAspNetCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // TODO:不支持秒级cron?
            RecurringJob.AddOrUpdate("A10001", () => Print(), "*/1 * * * *", TimeZoneInfo.Local);
            return View();
        }

        public void Print()
        {
            _logger.LogInformation(DateTime.Now.ToString("yyyy年MM月dd日 HH分mm分ss秒"));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
