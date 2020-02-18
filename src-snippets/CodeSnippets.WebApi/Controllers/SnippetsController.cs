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

        [Route("exception")]
        [HttpGet]
        public string Exception()
        {
            throw new BusinessException("Test Business Exception Message");
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            // 1. Using HttpClientFactory Directly
            var client = _httpClientFactory.CreateClient();
            //var result = await client.GetStringAsync("https://docs.microsoft.com/zh-cn/");
            //return result;
            client.BaseAddress = new Uri("https://api.github.com/");
            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Snippets");
            string result = await client.GetStringAsync("/");
            return Ok(result);
        }
    }
}