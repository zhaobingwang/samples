using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AspNetBoilerplateVue.EntityFrameworkCore
{
    public static class AspNetBoilerplateVueDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AspNetBoilerplateVueDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AspNetBoilerplateVueDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
