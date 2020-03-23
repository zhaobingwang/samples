using Abp.Application.Services;
using AspNetBoilerplate.MultiTenancy.Dto;

namespace AspNetBoilerplate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

