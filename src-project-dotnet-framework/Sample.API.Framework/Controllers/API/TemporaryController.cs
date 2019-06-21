using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sample.API.Framework.Controllers.API
{
    [RoutePrefix("api/temporary")]
    public class TemporaryController : ApiController
    {
        [HttpGet]
        [Route("t1")]
        public IHttpActionResult T1()
        {
            Thread.Sleep(5000);
            ThreadPool.GetMinThreads(out var minWorkerThreadCount, out var minIoThreadCount);
            ThreadPool.GetMaxThreads(out var maxWorkerThreadCount, out var maxIoThreadCount);
            //return Ok(DateTime.Now);
            return Ok($"{minWorkerThreadCount}-{minIoThreadCount}| {maxWorkerThreadCount}-{maxIoThreadCount}");
        }

        [HttpGet]
        [Route("t2")]
        public async Task<IHttpActionResult> T2()
        {
            await Task.Delay(5000);
            return Ok(DateTime.Now);
        }
    }
}
