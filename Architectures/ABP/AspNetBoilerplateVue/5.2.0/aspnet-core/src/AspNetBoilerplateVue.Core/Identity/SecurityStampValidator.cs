using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using AspNetBoilerplateVue.Authorization.Roles;
using AspNetBoilerplateVue.Authorization.Users;
using AspNetBoilerplateVue.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace AspNetBoilerplateVue.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
