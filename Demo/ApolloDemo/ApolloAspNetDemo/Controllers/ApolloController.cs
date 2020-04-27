using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApolloAspNetDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApolloController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        public ApolloController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return Ok("no key.");

            var value = Configuration[key];
            if (string.IsNullOrWhiteSpace(value))
                return Ok("no value.");
            return Ok($"{key}:{value}");
        }
    }
}