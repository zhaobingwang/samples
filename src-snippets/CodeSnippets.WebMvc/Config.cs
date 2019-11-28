using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.WebMvc
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetResource()
        {
            return new List<ApiResource> {
                new ApiResource("api","API Application")
            };

        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client(){
                    ClientId="mvc",
                    AllowedGrantTypes=GrantTypes.Implicit,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    RequireConsent=false,
                    RedirectUris={ "http://localhost:5001/signin-oidc"},
                    PostLogoutRedirectUris={ "http://localhost:5001/signout-callback-oidc"},
                    AllowedScopes={
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId
                    }
                }
            };
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static List<TestUser> GetTestUsers()
        {
            return new List<TestUser> {
                new TestUser{
                    SubjectId="1",
                    Username="admin",
                    Password="123456"
                }
            };
        }
    }
}
