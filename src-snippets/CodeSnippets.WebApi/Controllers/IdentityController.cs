using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.WebApi.Controllers
{
    [Route("identity")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        public IActionResult Get()
        {
            return new JsonResult(User.Claims.Select(c => new { c.Type, char.MinValue }));
        }
    }
}