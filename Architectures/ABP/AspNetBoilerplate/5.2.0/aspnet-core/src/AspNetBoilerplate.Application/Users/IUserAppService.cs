using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AspNetBoilerplate.Roles.Dto;
using AspNetBoilerplate.Users.Dto;

namespace AspNetBoilerplate.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
