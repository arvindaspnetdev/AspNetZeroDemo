using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AspnetboilerplateDemo.Configuration.Dto;

namespace AspnetboilerplateDemo.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AspnetboilerplateDemoAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
