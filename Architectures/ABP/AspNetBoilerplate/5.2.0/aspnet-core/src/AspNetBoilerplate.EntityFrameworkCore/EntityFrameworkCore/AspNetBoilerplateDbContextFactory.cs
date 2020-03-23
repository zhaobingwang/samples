using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AspNetBoilerplate.Configuration;
using AspNetBoilerplate.Web;

namespace AspNetBoilerplate.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AspNetBoilerplateDbContextFactory : IDesignTimeDbContextFactory<AspNetBoilerplateDbContext>
    {
        public AspNetBoilerplateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AspNetBoilerplateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AspNetBoilerplateDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AspNetBoilerplateConsts.ConnectionStringName));

            return new AspNetBoilerplateDbContext(builder.Options);
        }
    }
}
