using System.Collections.Generic;
using AspNetBoilerplate.Roles.Dto;

namespace AspNetBoilerplate.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
