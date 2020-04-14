using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Areas.Identity.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Authorization;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Pages.Contacts
{
    #region snippet
    public class IndexModel : DI_BasePageModel
    {
        public IndexModel(
            DevelopContext context,
            IAuthorizationService authorizationService,
            UserManager<AppUser> userManager)
            : base(context, authorizationService, userManager)
        {
        }

        public IList<Contact> Contact { get; set; }

        public async Task OnGetAsync()
        {
            var contacts = from c in Context.Contacts
                           select c;

            var isAuthorized = User.IsInRole(Constants.ContactManagersRole) ||
                               User.IsInRole(Constants.ContactAdministratorsRole);

            var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them
            // or you are the owner.
            if (!isAuthorized)
            {
                contacts = contacts.Where(c => c.Status == ContactStatus.Approved
                                            || c.OwnerID == currentUserId);
            }

            Contact = await contacts.ToListAsync();
        }
    }
    #endregion
}