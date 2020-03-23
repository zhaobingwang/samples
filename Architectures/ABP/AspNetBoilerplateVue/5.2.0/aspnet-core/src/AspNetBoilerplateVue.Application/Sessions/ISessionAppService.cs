using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetBoilerplateVue.Sessions.Dto;

namespace AspNetBoilerplateVue.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
