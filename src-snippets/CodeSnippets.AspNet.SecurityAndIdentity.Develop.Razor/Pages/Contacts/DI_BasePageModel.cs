using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Areas.Identity.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Pages.Contacts
{
    public class DI_BasePageModel : PageModel
    {
        protected DevelopContext Context { get; }
        protected IAuthorizationService AuthorizationService { get; }
        protected UserManager<AppUser> UserManager { get; }

        public DI_BasePageModel(
            DevelopContext context,
            IAuthorizationService authorizationService,
            UserManager<AppUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        } 
    }
}
