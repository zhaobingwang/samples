using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSnippets.IdentityCenter.Entities;
using CodeSnippets.IdentityCenter.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CodeSnippets.IdentityCenter.Controllers
{
    public class AccountController : Controller
    {
        //private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;

        private readonly TestUserStore _users;

        public AccountController(TestUserStore users)
        {
            _users = users;
        }
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = _users.FindByUsername(loginViewModel.UserName);
            if (user == null)
            {
                ModelState.AddModelError(nameof(loginViewModel.UserName), "User not exists");
            }
            else
            {
                if (_users.ValidateCredentials(loginViewModel.UserName, loginViewModel.Password))
                {
                    var props = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(30))
                    };

                    await Microsoft.AspNetCore.Http.AuthenticationManagerExtensions.SignInAsync(HttpContext, user.SubjectId, user.Username, props);
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(nameof(loginViewModel.Password), "Wrong password");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}