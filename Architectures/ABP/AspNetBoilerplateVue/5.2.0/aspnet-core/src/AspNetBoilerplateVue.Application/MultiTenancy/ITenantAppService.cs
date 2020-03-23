using Abp.Application.Services;
using AspNetBoilerplateVue.MultiTenancy.Dto;

namespace AspNetBoilerplateVue.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

