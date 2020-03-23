using System.Collections.Generic;
using AspNetBoilerplate.Roles.Dto;

namespace AspNetBoilerplate.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}