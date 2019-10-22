using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using CodeSnippets.WebMvc.Models;
using Microsoft.AspNetCore.Identity;
using CodeSnippets.WebMvc.Entities;
using IdentityServer4.Test;

namespace CodeSnippets.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        //private UserManager<ApplicationUser> _userManager;
        //private SignInManager<ApplicationUser> _signInManager;

        //public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //}

        private readonly TestUserStore _users;
        public AccountController(TestUserStore users)
        {
            _users = users;
        }

        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel, string returnUrl = null)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View();
            //}
            //ViewData["ReturnUrl"] = returnUrl;
            //var identityUser = new ApplicationUser
            //{
            //    Email = registerViewModel.Email,
            //    UserName = registerViewModel.Email,
            //    NormalizedUserName = registerViewModel.Email
            //};

            //var identityResult = await _userManager.CreateAsync(identityUser, registerViewModel.Password);

            //if (identityResult.Succeeded)
            //{
            //    await _signInManager.SignInAsync(identityUser, new AuthenticationProperties { IsPersistent = true });
            //    return RedirectToLocal(returnUrl);
            //}
            //else
            //{
            //    AddErrors(identityResult);
            //}

            return View();
        }

        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            ViewData["ReturnUrl"] = returnUrl;
            //var user = await _userManager.FindByEmailAsync(loginViewModel.Email);
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
                    //HttpContext.SignInAsync(user.SubjectId, user.Username, props);
                    await Microsoft.AspNetCore.Http.AuthenticationManagerExtensions.SignInAsync(
                        HttpContext,
                        user.SubjectId,
                        user.Username,
                        props
                    );
                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(nameof(loginViewModel.Password), "Wrong password");
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
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

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
};