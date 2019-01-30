using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var work = ActualWork(3000);
            var timeout = Timeout(2000);
            var finishedTask = await Task.WhenAny(work, timeout);
            if (finishedTask == timeout)
            {
                return StatusCode(408);
            }
            else
            {
                return StatusCode(200, "Success of get data.");
            }
        }
        private async Task<string> ActualWork(int sleepTime)
        {
            await Task.Delay(sleepTime);
            return "work results";
        }
        private async Task Timeout(int timeoutValue)
        {
            await Task.Delay(timeoutValue);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
