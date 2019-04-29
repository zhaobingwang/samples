using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GBController : ControllerBase
    {
        public async Task<string> Get(string type, string version)
        {
            var json = await System.IO.File.ReadAllTextAsync($"{AppDomain.CurrentDomain.BaseDirectory}/data/GB/GB-{type}-{version}.json");
            return json;
        }
    }
}