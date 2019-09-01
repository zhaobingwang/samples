using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace CodeSnippets.WebApi
{
    public class MyTokenValidator : ISecurityTokenValidator
    {
        public bool CanValidateToken => true;

        public int MaximumTokenSizeInBytes { get; set; }

        public bool CanReadToken(string securityToken)
        {
            return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            validatedToken = null;
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);

            if (securityToken == "123456")
            {
                identity.AddClaim(new Claim("name", "admin"));
                identity.AddClaim(new Claim("SuperAdminOnly", "true"));
                identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, "admin"));
            }


            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}
