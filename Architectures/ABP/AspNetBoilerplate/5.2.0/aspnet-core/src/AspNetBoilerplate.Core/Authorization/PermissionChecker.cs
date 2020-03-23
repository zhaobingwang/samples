using Abp.Authorization;
using AspNetBoilerplate.Authorization.Roles;
using AspNetBoilerplate.Authorization.Users;

namespace AspNetBoilerplate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
