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
        public DbSet<Movie> Movies { get; set; }
    }
}
