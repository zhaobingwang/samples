using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample.NetCore.Web.Controllers
{
    public class FilesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Files")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            foreach (var formFile in files)
            {
                if (formFile.Length <= 0)
                    continue;
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            return Ok(new { count = files.Count, size, filePath });
        }

        //[HttpPost]
        //[DisableFormValueModelBinding]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Upload()
        //{

        //}
    }
}