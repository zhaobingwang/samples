using Abp.AutoMapper;
using AspNetBoilerplate.Roles.Dto;
using AspNetBoilerplate.Web.Models.Common;

namespace AspNetBoilerplate.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
