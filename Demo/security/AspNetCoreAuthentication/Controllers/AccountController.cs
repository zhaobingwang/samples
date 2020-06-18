using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AspNetCoreAuthentication.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreAuthentication.Controllers
{
    public class AccountController : Controller
    {
        UserRepository _userRepository;
        public AccountController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Login(string returnUrl)
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
                returnUrl = "/";
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl)
        {
            var user = _userRepository.findUser(userName, password);
            if (user == null)
                return Redirect("/");
            var claimIdentity = new ClaimsIdentity("Cookie");
            claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Name));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            claimIdentity.AddClaim(new Claim(ClaimTypes.MobilePhone, user.PhoneNumber));
            claimIdentity.AddClaim(new Claim(ClaimTypes.DateOfBirth, user.Birthday.ToString()));

            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            // 在Startup中注册AddAuthentication时，指定了默认的Scheme，在这里便可以不再指定Scheme
            await HttpContext.SignInAsync(claimPrincipal);
            if (string.IsNullOrWhiteSpace(returnUrl))
                return Redirect("/");
            else
                return Redirect(returnUrl);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Profile()
        {
            ViewBag.Name = HttpContext.User.Identity.Name;
            return View();
        }
    }
}
