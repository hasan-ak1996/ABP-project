using Volo.Abp.Modularity;

namespace AbpIoTest
{
    [DependsOn(
        typeof(AbpIoTestApplicationModule),
        typeof(AbpIoTestDomainTestModule)
        )]
    public class AbpIoTestApplicationTestModule : AbpModule
    {

    }
}