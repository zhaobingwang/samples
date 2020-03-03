using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeSnippets.WebApi.Controllers
{
    [ApiController]
    [Route("params4post")]
    public class PostParamsSampleController : Controller
    {

        /// <summary>
        /// Content-Type: application/json
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("json")]
        public IActionResult ParamsA(Model model)
        {
            return Ok($"{model.value1}-{model.value2}");
        }

        /// <summary>
        /// Content-Type: application/x-www-form-urlencoded
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("xwfu")]
        public IActionResult ParamsB([FromForm]Model model)
        {
            return Ok($"{model.value1}-{model.value2}");
        }

        //public IActionResult ParamsB([FromForm]string value1, [FromForm]int value2)
        //{
        //    return Ok($"{value1}-{value2}");
        //}

        /// <summary>
        /// Content-Type: multipart/form-data
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("mfd")]
        public IActionResult ParamsC([FromForm]IFormFile value1, [FromForm]string value2)
        {
            return Ok($"{value1.FileName}-{value2}");
        }
    }

    public class Model
    {
        public string value1 { get; set; }
        public int value2 { get; set; }
    }
}
