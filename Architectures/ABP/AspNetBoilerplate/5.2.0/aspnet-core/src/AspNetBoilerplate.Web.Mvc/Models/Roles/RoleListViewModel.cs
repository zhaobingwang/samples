using System.Collections.Generic;
using AspNetBoilerplate.Roles.Dto;

namespace AspNetBoilerplate.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
