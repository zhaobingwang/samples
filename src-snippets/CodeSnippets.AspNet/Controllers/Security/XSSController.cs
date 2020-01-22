using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.AspNet.Controllers
{
    public class XSSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Stored()
        {
            var script = "<script>alert('stored xss')</script>";
            ViewBag.StoredXSS = script;
            return View(nameof(Index));
        }
    }
}