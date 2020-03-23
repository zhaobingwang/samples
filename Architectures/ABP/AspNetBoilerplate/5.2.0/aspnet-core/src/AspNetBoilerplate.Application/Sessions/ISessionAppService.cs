using System.Threading.Tasks;
using Abp.Application.Services;
using AspNetBoilerplate.Sessions.Dto;

namespace AspNetBoilerplate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
