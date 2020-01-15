using CodeSnippets.IdentityCenter.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.IdentityCenter.Data
{
    public class AspNetAccountDbContext : IdentityDbContext<ApplicationUser>
    {
        public AspNetAccountDbContext(DbContextOptions<AspNetAccountDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
