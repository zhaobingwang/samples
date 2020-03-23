using System.Threading.Tasks;
using AspNetBoilerplateVue.Configuration.Dto;

namespace AspNetBoilerplateVue.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
