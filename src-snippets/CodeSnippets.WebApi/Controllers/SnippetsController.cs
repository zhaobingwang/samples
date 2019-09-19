using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.WebApi.Controllers
{
    /// <summary>
    /// 一些还未归类的代码片段集合
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SnippetsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult<string>> Get()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetStringAsync("https://docs.microsoft.com/zh-cn/");
            return result;
        }
    }
}