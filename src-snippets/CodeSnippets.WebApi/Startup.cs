using CodeSnippets.WebApi.Models;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace CodeSnippets.WebApi
{
    /// <summary>
    /// 从 ASP.NET Core 2.2 迁移到3.0:
    /// https://docs.microsoft.com/zh-cn/aspnet/core/migration/22-to-30?view=aspnetcore-3.0&tabs=visual-studio
    /// </summary>
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
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            var jwtSettings = new JwtSettings();
            Configuration.Bind("JwtSettings", jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };

                #region 定制JWT，在基于Role授权不管用，可在使用Policy授权下使用
                //o.SecurityTokenValidators.Clear();
                //o.SecurityTokenValidators.Add(new MyTokenValidator());

                //o.Events = new JwtBearerEvents()
                //{
                //    OnMessageReceived = context =>
                //    {
                //        var token = context.Request.Headers["mytoken"];
                //        context.Token = token.FirstOrDefault();
                //        return Task.CompletedTask;
                //    }
                //}; 
                #endregion

            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperAdminOnly", policy => policy.RequireClaim("SuperAdminOnly"));
            });

            services.AddControllers();
            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
            });
        }
    }
}
