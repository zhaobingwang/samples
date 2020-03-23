using Abp.AutoMapper;
using AspNetBoilerplateVue.Authentication.External;

namespace AspNetBoilerplateVue.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
