using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.IdentityCenter
{
    public static class Config
    {
        // Defining an API Resource
        public static IEnumerable<ApiResource> Apis => new List<ApiResource>
        {
            new ApiResource("CodeSnippets.WebApi","CodeSnippets API")
        };

        // Defining Client
        public static IEnumerable<Client> Clients => new List<Client>
        {
            new Client
            {
                ClientId="client",

                // no interactive user, use the clientid/secret for authentication
                AllowedGrantTypes=GrantTypes.ClientCredentials,

                // secret for authentication
                ClientSecrets={
                    new Secret("secret".Sha256())
                },

                // scopes that client has access to
                AllowedScopes={ "CodeSnippets.WebApi" }
            },
            new Client
            {
                ClientId="mvc",
                ClientSecrets={new Secret("secret".Sha256())},

                AllowedGrantTypes=GrantTypes.Code,
                RequireConsent=false,
                RequirePkce=true,

                RedirectUris={ "http://localhost:5002/signin-oidc"},

                PostLogoutRedirectUris={ "http://localhost:/5002/signout-callback-oidc"},

                AllowedScopes=new List<string>{
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "CodeSnippets.WebApi"   // 启用对刷新令牌的支持
                },

                AllowOfflineAccess=true
            }
        };


        // Defineing Identity Resource
        public static IEnumerable<IdentityResource> Ids => new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
    }
}
