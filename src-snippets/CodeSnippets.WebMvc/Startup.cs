using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CodeSnippets.WebMvc
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionString);
            //});

            //services.AddIdentity<ApplicationUser, ApplicationRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            #region MyRegion
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryClients(Config.GetClients())
            //    .AddInMemoryApiResources(Config.GetResource())
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    //.AddConfigurationStore(options =>
            //    //{
            //    //    options.ConfigureDbContext = builder =>
            //    //    {
            //    //        builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            //    //    };
            //    //})
            //    //.AddOperationalStore(options =>
            //    //{
            //    //    options.ConfigureDbContext = builder =>
            //    //    {
            //    //        builder.UseSqlServer(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly));
            //    //    };
            //    //})
            //    .AddAspNetIdentity<ApplicationUser>()
            //    .Services.AddTransient<IProfileService, ProfileService>();


            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Password.RequireLowercase = false;
            //    options.Password.RequireNonAlphanumeric = false;
            //    options.Password.RequireUppercase = false;
            //    options.Password.RequiredLength = 6;
            //});

            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});

            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie(options =>
            //    {
            //        options.LoginPath = "/Account/Login";
            //        //options.AccessDeniedPath = "";
            //    }); 
            #endregion


            //services.AddScoped<ConsentService>();

            // 将身份验证服务添加到DI
            // 我们使用cookie来本地登录用户（通过“Cookies”作为DefaultScheme），并且将DefaultChallengeScheme设置为oidc。因为当我们需要用户登录时，我们将使用OpenID Connect协议。
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            // 添加可以处理cookie的处理程序
            .AddCookie("Cookies")
            // 用于配置执行OpenID Connect协议的处理程序
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "http://localhost:5000";    // 指示了受信任令牌服务地址
                options.RequireHttpsMetadata = false;

                options.ClientId = "mvc";
                options.ClientSecret = "secret";
                options.ResponseType = "code";

                options.SaveTokens = true;  // 用于将来自IdentityServer的令牌保留在cookie中
            });

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //InitIdentityServerDataBase(app);

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            //app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireAuthorization();    // RequireAuthorization方法禁用整个应用程序的匿名访问
            });
        }

        //public void InitIdentityServerDataBase(IApplicationBuilder app)
        //{
        //    using (var scope = app.ApplicationServices.CreateScope())
        //    {
        //        scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
        //        var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();

        //        if (!configurationDbContext.Clients.Any())
        //        {
        //            foreach (var client in Config.GetClients())
        //            {
        //                configurationDbContext.Clients.Add(client.ToEntity());
        //            }
        //            configurationDbContext.SaveChanges();
        //        }
        //        if (!configurationDbContext.ApiResources.Any())
        //        {
        //            foreach (var api in Config.GetResource())
        //            {
        //                configurationDbContext.ApiResources.Add(api.ToEntity());
        //            }
        //            configurationDbContext.SaveChanges();
        //        }
        //        if (!configurationDbContext.IdentityResources.Any())
        //        {
        //            foreach (var identity in Config.GetIdentityResources())
        //            {
        //                configurationDbContext.IdentityResources.Add(identity.ToEntity());
        //            }
        //            configurationDbContext.SaveChanges();
        //        }
        //    }
        //}
    }
}
