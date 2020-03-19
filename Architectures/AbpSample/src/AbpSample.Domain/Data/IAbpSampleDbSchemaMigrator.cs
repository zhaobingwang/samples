using System.Threading.Tasks;

namespace AbpSample.Data
{
    public interface IAbpSampleDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
