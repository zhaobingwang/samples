using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetBoilerplateVue.Authorization.Accounts.Dto;

namespace AspNetBoilerplateVue.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
