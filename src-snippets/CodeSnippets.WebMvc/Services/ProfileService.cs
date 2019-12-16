using CodeSnippets.WebMvc.Entities;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeSnippets.WebMvc.Services
{
    public class ProfileService : IProfileService
    {
        private UserManager<ApplicationUser> _userManager;
        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var subjectId = context.Subject.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var user = await _userManager.FindByNameAsync(subjectId);

            var claims = await GetClaimsFromUserAsync(user);
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = false;

            var subjectId = context.Subject.Claims.FirstOrDefault(c => c.Type == "sub").Value;
            var user = await _userManager.FindByNameAsync(subjectId);

            context.IsActive = user != null;

        }

        private async Task<List<Claim>> GetClaimsFromUserAsync(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Subject,user.Id.ToString()),
                new Claim(JwtClaimTypes.PreferredUserName,user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, role));
            }

            if (!string.IsNullOrWhiteSpace(user.Avatar))
            {
                claims.Add(new Claim("avatar", user.Avatar));
            }

            return claims;
        }
    }
}
