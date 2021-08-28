using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AspnetboilerplateDemo.Controllers
{
    public abstract class AspnetboilerplateDemoControllerBase: AbpController
    {
        protected AspnetboilerplateDemoControllerBase()
        {
            LocalizationSourceName = AspnetboilerplateDemoConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
