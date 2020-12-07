using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpIoTest.Data
{
    /* This is used if database provider does't define
     * IAbpIoTestDbSchemaMigrator implementation.
     */
    public class NullAbpIoTestDbSchemaMigrator : IAbpIoTestDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}