using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CodeSnippets.WebApi.Models;
using CodeSnippets.WebApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CodeSnippets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private JwtSettings _jwtSettings;
        public AuthorizeController(IOptions<JwtSettings> jwtSetting)
        {
            _jwtSettings = jwtSetting.Value;
        }

        [HttpPost("token")]
        public IActionResult Token([FromBody]LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!(viewModel.User == "admin" && viewModel.Password == "123456"))
            {
                return BadRequest();
            }

            var claim = new Claim[] {
                new Claim(ClaimTypes.Name,"admin"),
                new Claim(ClaimTypes.Role,"admin")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Audience,
                claim,
                DateTime.Now,
                DateTime.Now.AddMinutes(30),
                creds);
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}