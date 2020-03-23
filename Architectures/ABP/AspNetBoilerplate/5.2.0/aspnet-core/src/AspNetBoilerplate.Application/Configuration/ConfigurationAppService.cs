using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AspNetBoilerplate.Configuration.Dto;

namespace AspNetBoilerplate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AspNetBoilerplateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
