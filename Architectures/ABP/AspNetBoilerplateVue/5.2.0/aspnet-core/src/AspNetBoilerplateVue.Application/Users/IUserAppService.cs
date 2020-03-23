using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AspNetBoilerplateVue.Roles.Dto;
using AspNetBoilerplateVue.Users.Dto;

namespace AspNetBoilerplateVue.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
