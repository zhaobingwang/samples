using Abp.Application.Services.Dto;

namespace AspNetBoilerplate.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

