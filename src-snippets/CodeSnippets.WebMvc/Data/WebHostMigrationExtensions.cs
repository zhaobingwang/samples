using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.WebMvc.Data
{
    public static class WebHostMigrationExtensions
    {
        public static IWebHost MigrationDbContext<TContext>(this IWebHost host, Action<TContext, IServiceProvider> sedder) where TContext : DbContext
        {
            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var logger = service.GetRequiredService<ILogger<TContext>>();
                var context = service.GetService<TContext>();

                try
                {
                    context.Database.Migrate();
                    sedder(context, service);
                    logger.LogInformation($"执行DbContext{typeof(TContext).Name} seed执行");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"执行DbContext {typeof(TContext).Name} seed方法失败");
                }
            }
            return host;
        }
    }
}
