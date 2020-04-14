using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Areas.Identity.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Authorization;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Pages.Contacts
{
    #region snippet
    public class DetailsModel : DI_BasePageModel
    {
        public DetailsModel(
            DevelopContext context,
            IAuthorizationService authorizationService,
            UserManager<AppUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await Context.Contacts.FirstOrDefaultAsync(m => m.ContactId == id);

            if (Contact == null)
            {
                return NotFound();
            }

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            if (!isAuthorized
                && currentUserId != Contact.OwnerID
                && Contact.Status != ContactStatus.Approved)
            {
                return Forbid();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, ContactStatus status)
        {
            var contact = await Context.Contacts.FirstOrDefaultAsync(
                                                      m => m.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            var contactOperation = (status == ContactStatus.Approved)
                                                       ? ContactOperations.Approve
                                                       : ContactOperations.Reject;

            var isAuthorized = await AuthorizationService.AuthorizeAsync(User, contact,
                                        contactOperation);
            if (!isAuthorized.Succeeded)
            {
                return Forbid();
            }
            contact.Status = status;
            Context.Contacts.Update(contact);
            await Context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
    #endregion
}
