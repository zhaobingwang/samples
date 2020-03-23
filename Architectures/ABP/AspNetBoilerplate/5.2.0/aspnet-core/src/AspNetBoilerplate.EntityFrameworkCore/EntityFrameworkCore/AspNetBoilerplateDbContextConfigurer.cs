using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AspNetBoilerplate.EntityFrameworkCore
{
    public static class AspNetBoilerplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AspNetBoilerplateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AspNetBoilerplateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
