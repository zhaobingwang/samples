using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpSample.Data;
using Volo.Abp.DependencyInjection;

namespace AbpSample.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpSampleDbSchemaMigrator
        : IAbpSampleDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpSampleDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpSampleMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpSampleMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}