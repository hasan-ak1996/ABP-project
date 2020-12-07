using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace AbpIoTest.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpIoTestEntityFrameworkCoreModule)
        )]
    public class AbpIoTestEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpIoTestMigrationsDbContext>();
        }
    }
}
