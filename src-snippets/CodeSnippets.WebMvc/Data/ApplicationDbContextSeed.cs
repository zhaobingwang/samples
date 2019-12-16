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
        private RoleManager<ApplicationRole> _roleManager;
        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider services)
        {
            if (!context.Roles.Any())
            {
                _roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                var role = new ApplicationRole { Name = "Administrators", NormalizedName = "Administrators" };
                var result = await _roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    throw new Exception($"初始化默认角色失败：{result.Errors.SelectMany(e => e.Description)}");
                }
            }

            if (!context.Users.Any())
            {
                _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                _roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

                var defaultUser = new ApplicationUser
                {
                    UserName = "Administrator",
                    Email = "admin@admin.com",
                    NormalizedUserName = "admin",
                    SecurityStamp = "admin",
                    Avatar = "https://blog.tedd.no/wp-content/uploads/2019/06/128-Bitmap-BIG_ASP.NET-Core-MVC-Logo_2colors_Square_RGB.png"
                };


                var result = await _userManager.CreateAsync(defaultUser, "123456");
                await _userManager.AddToRoleAsync(defaultUser, "Administrators");

                if (!result.Succeeded)
                {
                    throw new Exception("初始化默认用户失败");
                }
            }
        }
    }
}
