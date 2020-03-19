using AbpSample.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpSample.Permissions
{
    public class AbpSamplePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(AbpSamplePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(AbpSamplePermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<AbpSampleResource>(name);
        }
    }
}
