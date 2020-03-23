using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AspNetBoilerplate.Authorization.Roles;
using AspNetBoilerplate.Authorization.Users;
using AspNetBoilerplate.MultiTenancy;

namespace AspNetBoilerplate.EntityFrameworkCore
{
    public class AspNetBoilerplateDbContext : AbpZeroDbContext<Tenant, Role, User, AspNetBoilerplateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AspNetBoilerplateDbContext(DbContextOptions<AspNetBoilerplateDbContext> options)
            : base(options)
        {
        }
    }
}
