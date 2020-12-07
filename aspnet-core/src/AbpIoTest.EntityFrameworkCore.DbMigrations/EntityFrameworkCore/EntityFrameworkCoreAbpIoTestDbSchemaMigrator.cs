using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpIoTest.Data;
using Volo.Abp.DependencyInjection;

namespace AbpIoTest.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpIoTestDbSchemaMigrator
        : IAbpIoTestDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpIoTestDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpIoTestMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpIoTestMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}