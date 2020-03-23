using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AspNetBoilerplateVue.Authorization.Roles;
using AspNetBoilerplateVue.Authorization.Users;
using AspNetBoilerplateVue.MultiTenancy;

namespace AspNetBoilerplateVue.EntityFrameworkCore
{
    public class AspNetBoilerplateVueDbContext : AbpZeroDbContext<Tenant, Role, User, AspNetBoilerplateVueDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AspNetBoilerplateVueDbContext(DbContextOptions<AspNetBoilerplateVueDbContext> options)
            : base(options)
        {
        }
    }
}
