using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSnippets.IdentityCenter.Models;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Mvc;
using CodeSnippets.IdentityCenter.Service;

namespace CodeSnippets.IdentityCenter.Controllers
{
    public class ConsentController : Controller
    {
        private readonly ConsentService _consentService;
        public ConsentController(ConsentService consentService)
        {
            _consentService = consentService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl)
        {
            var vm = await _consentService.BuildConsentViewModelAsync(returnUrl);
            if (vm == null)
            {
                return View("Error");
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConsentInputModel model)
        {
            var result = await _consentService.ProcessConsentAsync(model);
            if (result.IsRedirect)
            {
                return Redirect(result.RedirectUrl);
            }
            if (!string.IsNullOrEmpty(result.ValidationError))
            {
                ModelState.AddModelError("", result.ValidationError);
            }
            return View(result.ViewModel);
        }
    }
}