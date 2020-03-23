using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AspNetBoilerplateVue.Configuration;
using AspNetBoilerplateVue.Web;

namespace AspNetBoilerplateVue.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AspNetBoilerplateVueDbContextFactory : IDesignTimeDbContextFactory<AspNetBoilerplateVueDbContext>
    {
        public AspNetBoilerplateVueDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AspNetBoilerplateVueDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AspNetBoilerplateVueDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AspNetBoilerplateVueConsts.ConnectionStringName));

            return new AspNetBoilerplateVueDbContext(builder.Options);
        }
    }
}
