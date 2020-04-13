using System;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Areas.Identity.Data;
using CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Areas.Identity.IdentityHostingStartup))]
namespace CodeSnippets.AspNet.SecurityAndIdentity.Develop.Razor.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DevelopContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DevelopContextConnection")));

                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DevelopContext>();
            });
        }
    }
}