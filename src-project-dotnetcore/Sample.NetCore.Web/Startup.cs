using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Sample.NetCore.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Sample.NetCore.ApplicationCore.Interfaces;
using Sample.NetCore.ApplicationCore.Services;
using Sample.NetCore.Web.Services;
using Sample.NetCore.Infrastructure.Interfaces;
using Sample.NetCore.Infrastructure.Repositories;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Web.Hubs;

namespace Sample.NetCore.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MSSQLContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MSSQLContext")));

            services.AddDbContext<PostgreSQLContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("PostgreSQLContext")));

            services.AddMvc(options =>
            {
                options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // services
            // Transient objects are always different; a new instance is provided to every controller and every service.
            // Scoped objects are the same within a request, but different across different requests.
            // Singleton objects are the same for every object and every request.
            services.AddSingleton<IDateTime, SystemDateTime>();
            services.AddSingleton<ProfileOptionsService>();
            services.Configure<Settings>(Configuration);
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();

            // signalr
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //var repository = app.ApplicationServices.GetService<ITodoItemRepository>();
                //InitializeDatabaseAsync(repository).Wait();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
                //// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chathub");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "items",
                    template: "Items/{country}/{action}",
                    defaults: new { controller = "Items" });
            });
        }
    }
}
