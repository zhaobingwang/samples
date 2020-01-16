using CodeSnippets.IdentityCenter.Data;
using CodeSnippets.IdentityCenter.Entities;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Interfaces;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.EntityFramework.Storage;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CodeSnippets.IdentityCenter
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var migtationAssembly = typeof(SeedData).GetTypeInfo().Assembly.GetName().Name;
            var service = new ServiceCollection();
            service.AddConfigurationDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migtationAssembly));
            });
            service.AddOperationalDbContext(options =>
            {
                options.ConfigureDbContext = db => db.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migtationAssembly));
            });

            var serviceProvider = service.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<PersistedGrantDbContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetService<ConfigurationDbContext>();
                context.Database.Migrate();
                EnsureSeedData(context);
            }
        }

        private static void EnsureSeedData(IConfigurationDbContext context)
        {
            if (!context.Clients.Any())
            {
                foreach (var client in Config.Clients)
                {
                    context.Clients.Add(client.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.ApiResources.Any())
            {
                foreach (var api in Config.Apis)
                {
                    context.ApiResources.Add(api.ToEntity());
                }
                context.SaveChanges();
            }

            if (!context.IdentityResources.Any())
            {
                foreach (var id in Config.Ids)
                {
                    context.IdentityResources.Add(id.ToEntity());
                }
                context.SaveChanges();
            }
        }

        public static void EnsureSeedAspNetAccountData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AspNetAccountDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AspNetAccountDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<AspNetAccountDbContext>();
                    context.Database.Migrate();

                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    var zhangsan = userManager.FindByNameAsync("zhangsan").Result;
                    if (zhangsan == null)
                    {
                        zhangsan = new ApplicationUser
                        {
                            UserName = "zhangsan",
                            Email = "zhangsan@email.com"
                        };
                        var result = userManager.CreateAsync(zhangsan, "123456").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        result = userManager.AddClaimsAsync(zhangsan, new Claim[] {
                            new Claim(JwtClaimTypes.Name, "张三"),
                            new Claim(JwtClaimTypes.GivenName, "三"),
                            new Claim(JwtClaimTypes.FamilyName, "张"),
                            new Claim(JwtClaimTypes.Email, "zhangsan@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://zhangsan.com"),
                            new Claim(JwtClaimTypes.Address, @"{ '城市': '杭州', '邮政编码': '310000' }",
                                IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                    }

                    var lisi = userManager.FindByNameAsync("lisi").Result;
                    if (lisi == null)
                    {
                        lisi = new ApplicationUser
                        {
                            UserName = "lisi",
                            Email = "lisi@email.com"
                        };
                        var result = userManager.CreateAsync(lisi, "123456").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        result = userManager.AddClaimsAsync(zhangsan, new Claim[] {
                            new Claim(JwtClaimTypes.Name, "李四"),
                            new Claim(JwtClaimTypes.GivenName, "四"),
                            new Claim(JwtClaimTypes.FamilyName, "李"),
                            new Claim(JwtClaimTypes.Email, "lisi@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim(JwtClaimTypes.Address, @"{ '城市': '上海', '邮政编码': '200000' }",
                                IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
                            new Claim("location", "somewhere")
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                    }
                }
            }
        }
    }
}
