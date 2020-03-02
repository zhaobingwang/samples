using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("create-tag")]
        public async Task<IActionResult> CreateTag(int userId, string tag)
        {
            var tagModel = await _userService.CreateTag(userId, tag);
            return Ok(tagModel);
        }
    }
}