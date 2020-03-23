using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetBoilerplate.Authorization.Accounts.Dto;

namespace AspNetBoilerplate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
