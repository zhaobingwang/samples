using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sample.DotnetFramework.Controllers
{
    public class TestController : ApiController
    {
        [Route("test")]
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            await Task.Delay(1000);
            return Ok(DateTime.Now.ToString("hh:mm:ss"));
        }

        [Route("test2")]
        [HttpGet]
        public IHttpActionResult Get2()
        {
            Thread.Sleep(1000);
            return Ok(DateTime.Now.ToString("hh:mm:ss"));
        }
    }
}
