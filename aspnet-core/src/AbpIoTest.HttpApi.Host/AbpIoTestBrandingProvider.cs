using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpIoTest
{
    [Dependency(ReplaceServices = true)]
    public class AbpIoTestBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpIoTest";
    }
}
