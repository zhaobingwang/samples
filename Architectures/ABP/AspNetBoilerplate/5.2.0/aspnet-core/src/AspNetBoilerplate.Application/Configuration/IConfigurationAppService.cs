using System.Threading.Tasks;
using AspNetBoilerplate.Configuration.Dto;

namespace AspNetBoilerplate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
