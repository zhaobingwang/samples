using CodeSnippets.WebMvc.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSnippets.WebMvc.Data
{
    public class ApplicationDbContextSeed
    {
        private UserManager<ApplicationUser> _userManager;
        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider services)
        {
            if (!context.Users.Any())
            {
                _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var defaultUser = new ApplicationUser
                {
                    UserName = "Administrator",
                    Email = "admin@admin.com",
                    NormalizedUserName = "admin"
                };
                var result = await _userManager.CreateAsync(defaultUser, "Pwd123456");
                if (!result.Succeeded)
                {
                    throw new Exception("初始化默认用户失败");
                }
            }
        }
    }
}
