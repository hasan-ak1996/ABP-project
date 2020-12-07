using AbpIoTest.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpIoTest.Permissions
{
    public class AbpIoTestPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpIoTestPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpIoTestPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpIoTestResource>(name);
        }
    }
}
