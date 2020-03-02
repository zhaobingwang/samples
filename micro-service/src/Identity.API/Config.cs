using IdentityServer4.Models;
using System.Collections.Generic;

namespace Identity.API
{
    public static class Config
    {
        // Defining an API Resource
        public static IEnumerable<ApiResource> Apis => new List<ApiResource>
        {
            new ApiResource("User.Api","User Services")
        };

        // Defining Client
        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId="app_test",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes=GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets={
                    new Secret("123456".Sha256())
                },

                // scopes that client has access to
                AllowedScopes={ "User.Api" }
            }
        };


        // Defineing Identity Resource
        public static IEnumerable<IdentityResource> IdentityResources => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
    }
}
