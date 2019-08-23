using CodeSnippets.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Infrastructure
{
    public class NpgsqlEFContext : DbContext
    {
        //public NpgsqlEFContext(DbContextOptions<NpgsqlEFContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
               => optionsBuilder.UseNpgsql("Host=192.168.0.166;Database=NpgsqlEFContext;Username=postgres;Password=123456");

        public DbSet<Blog> Blog { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}
