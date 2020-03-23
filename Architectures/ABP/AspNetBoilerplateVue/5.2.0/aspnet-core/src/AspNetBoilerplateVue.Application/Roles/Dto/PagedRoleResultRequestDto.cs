using Abp.Application.Services.Dto;

namespace AspNetBoilerplateVue.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

