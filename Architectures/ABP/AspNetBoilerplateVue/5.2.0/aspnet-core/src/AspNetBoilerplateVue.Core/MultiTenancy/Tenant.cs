using Abp.MultiTenancy;
using AspNetBoilerplateVue.Authorization.Users;

namespace AspNetBoilerplateVue.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
