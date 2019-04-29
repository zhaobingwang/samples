using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;

namespace Sample.Infrastructure
{
    public class SampleContext : DbContext
    {
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>().Property(l => l.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Log>()
                .ToTable("Logs")
                .HasKey(l => l.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<T01> T01 { get; set; }
    }
}
