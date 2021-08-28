using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AspnetboilerplateDemo.Authorization
{
    public class AspnetboilerplateDemoAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Activation, L("UsersActivation"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Country, L("Country"));
            context.CreatePermission(PermissionNames.Pages_State, L("State"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AspnetboilerplateDemoConsts.LocalizationSourceName);
        }
    }
}
