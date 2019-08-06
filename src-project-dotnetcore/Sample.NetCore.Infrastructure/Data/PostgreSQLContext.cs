using Microsoft.EntityFrameworkCore;
using Sample.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.Infrastructure.Data
{
    public class PostgreSQLContext : DbContext
    {
        public PostgreSQLContext(DbContextOptions<PostgreSQLContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users")
                .HasDiscriminator<string>("user_type")
                .HasValue<ApplicationUser>("user_app")
                .HasValue<IdentityUser>("user_id");
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<IdentityUser> IdentityUser { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
