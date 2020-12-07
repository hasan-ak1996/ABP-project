using AbpIoTest.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpIoTest.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpIoTestEntityFrameworkCoreDbMigrationsModule),
        typeof(AbpIoTestApplicationContractsModule)
        )]
    public class AbpIoTestDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
