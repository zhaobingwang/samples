using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Areas.Identity.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Authorization;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Pages.Contacts
{
    #region snippet
    public class DeleteModel : DI_BasePageModel
    {
        public DeleteModel(
            DevelopContext context,
            IAuthorizationService authorizationService,
            UserManager<AppUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await Context.Contacts.FirstOrDefaultAsync(
                                                 m => m.ContactId == id);

            if (Contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, Contact,
                                                     ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var contact = await Context
                .Contacts.AsNoTracking()
                .FirstOrDefaultAsync(m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var isAuthorized = await AuthorizationService.AuthorizeAsync(
                                                     User, contact,
                                                     ContactOperations.Delete);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }

            Context.Contacts.Remove(contact);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    #endregion
}
