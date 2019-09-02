using CodeSnippets.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeSnippets.Infrastructure
{
    public class SqliteEFContext : DbContext
    {
        //public SqliteEFContext(DbContextOptions<SqliteEFContext> options) : base(options)
        //{

        //}


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=c:\db\sqlite\codesnippets.db");
        }

        public DbSet<SampleEntity> SampleEntity { get; set; }
    }
}
