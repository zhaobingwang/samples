using System.Collections.Generic;

namespace AspNetBoilerplateVue.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
