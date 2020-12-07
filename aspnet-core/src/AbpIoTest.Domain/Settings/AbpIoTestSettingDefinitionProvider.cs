using Volo.Abp.Settings;

namespace AbpIoTest.Settings
{
    public class AbpIoTestSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(AbpIoTestSettings.MySetting1));
        }
    }
}
