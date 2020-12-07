using System.Threading.Tasks;

namespace AbpIoTest.Data
{
    public interface IAbpIoTestDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
