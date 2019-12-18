using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.IdentityCenter
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis() => new List<ApiResource>
            {
                new ApiResource("api1","My API")
            };
    }
}
