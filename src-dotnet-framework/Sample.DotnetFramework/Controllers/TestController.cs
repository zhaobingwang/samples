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
            var a = await T1();
            //var b = await T2();
            return Ok($"a:{a}");
        }

        [Route("test2")]
        [HttpGet]
        public IHttpActionResult Get2()
        {
            Thread.Sleep(50);
            Thread.Sleep(50);
            return Ok(DateTime.Now.ToString("hh:mm:ss"));
        }


        private async Task<int> T1()
        {
            Task t1 = new Task(() =>
            {
                Thread.Sleep(50);
                //Task.Delay(800);
            });

            Task t2 = new Task(() =>
            {
                Thread.Sleep(50);
                //Task.Delay(200);
            });

            t1.Start();
            t2.Start();
            await Task.WhenAll(t1, t2);
            return 1;
        }
        private Task<int> T2()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(200);
                return 2;
            });
        }
    }
}
