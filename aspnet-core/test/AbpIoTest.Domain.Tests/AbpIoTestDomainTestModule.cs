using AbpIoTest.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpIoTest
{
    [DependsOn(
        typeof(AbpIoTestEntityFrameworkCoreTestModule)
        )]
    public class AbpIoTestDomainTestModule : AbpModule
    {

    }
}