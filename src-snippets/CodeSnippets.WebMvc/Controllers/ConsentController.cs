//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using CodeSnippets.WebMvc.Models;
//using Microsoft.AspNetCore.Mvc;
//using IdentityServer4.Models;
//using IdentityServer4.Services;
//using IdentityServer4.Stores;
//using CodeSnippets.WebMvc.Services;

//namespace CodeSnippets.WebMvc.Controllers
//{
//    public class ConsentController : Controller
//    {
//        private readonly ConsentService _consentService;
//        public ConsentController(ConsentService consentService)
//        {
//            _consentService = consentService;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Index(string returnUrl)
//        {
//            var model = await _consentService.BuildConsentViewModelAsync(returnUrl);
//            if (model == null)
//            {

//            }
//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Index(InputConsentViewModel viewModel)
//        {
//            var result = await _consentService.ProcessConsent(viewModel);
//            if (result.IsRedirect)
//            {
//                return Redirect(result.Redirecturl);
//            }
//            if (!string.IsNullOrEmpty(result.ValidationError))
//            {
//                ModelState.AddModelError("", result.ValidationError);
//            }
//            return View(result.ViewModel);
//        }
//    }
//}