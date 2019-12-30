using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.IS4UI
{
    public static class Config
    {
        // Defining an API Resource
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>{
                new ApiResource("CodeSnippets.WebApi","CodeSnippets API")
            };

        // Defining Client
        public static IEnumerable<Client> Clients =>
            new List<Client> {
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
                }
            };
    }
}
