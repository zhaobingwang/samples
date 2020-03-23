using Abp.Authorization;
using AspNetBoilerplateVue.Authorization.Roles;
using AspNetBoilerplateVue.Authorization.Users;

namespace AspNetBoilerplateVue.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
