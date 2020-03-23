using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AspNetBoilerplateVue.Configuration.Dto;

namespace AspNetBoilerplateVue.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AspNetBoilerplateVueAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
