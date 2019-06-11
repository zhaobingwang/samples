using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        [Route("get-string")]
        public string GetString()
        {
            return "hello,world";
        }

        [HttpGet]
        [Route("get-string-params")]
        public string GetString(int id, string name)
        {
            return $"{id},{name}";
        }

        [HttpPost]
        [Route("post-params")]
        public string PostParams([FromBody] string name)
        {
            return $"{nameof(name)}:{name}";
        }
    }
}