using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sample.API.Framework.Controllers
{
    public class TemporaryController : ApiController
    {
        public IHttpActionResult T1()
        {
            Thread.Sleep(30000);
            return Ok(DateTime.Now);
        }

        public async Task<IHttpActionResult> T2()
        {
            await Task.Delay(30000);
            return Ok(DateTime.Now);
        }
    }
}
