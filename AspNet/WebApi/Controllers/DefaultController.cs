using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly GitHubService _gitHubService;

        public DefaultController(IHttpClientFactory httpClient, GitHubService gitHubService)
        {
            _httpClient = httpClient;
            _gitHubService = gitHubService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = _httpClient.CreateClient("kit-mock-api");

            var response = await client.GetStringAsync("weatherforecast");
            return Ok(response);
        }

        [HttpGet("GetAspNetDocsIssues")]
        public async Task<IActionResult> GetAspNetDocsIssues()
        {
            var result = await _gitHubService.GetAspNetDocsIssues();
            return Ok(result);
        }
    }
}
