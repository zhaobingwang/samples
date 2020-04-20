using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.AspNet.WebMvc.Controllers
{
    public class EditorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Summernote()
        {
            var html = "<script>alert('hi')</script>";
            ViewData["html"] = html;
            return View();
        }

        [HttpPost]
        public IActionResult Summernote(PostData data)
        {
            return Ok();
        }

    }

    public class PostData
    {
        public string Content { get; set; }
    }
}