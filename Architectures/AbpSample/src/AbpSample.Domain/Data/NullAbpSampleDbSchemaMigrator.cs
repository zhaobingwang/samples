using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpSample.Data
{
    /* This is used if database provider does't define
     * IAbpSampleDbSchemaMigrator implementation.
     */
    public class NullAbpSampleDbSchemaMigrator : IAbpSampleDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}