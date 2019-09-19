using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BarcodeLib;

namespace Sample.Web.Framework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Image()
        {
            Barcode barcode = new Barcode();
            barcode.IncludeLabel = true;
            Image img = barcode.Encode(TYPE.CODE128, "038000356216", Color.Black, Color.White, 290, 120);

            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return File(ms.ToArray(), "image/png");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}