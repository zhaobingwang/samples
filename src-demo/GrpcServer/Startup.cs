using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrpcDemoServices;
using GrpcServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GrpcServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddSingleton<IncrementingCounter>();
            //services.AddScoped<IncrementingCounter>();

            // 使用EnableCallContextPropagation()将 gRPC 服务中的工厂创建的 gRPC 客户端配置为自动将截止时间和取消标记传播到子调用
            services.AddGrpcClient<Greeter.GreeterClient>((s, o) =>
            {
                o.Address = GetCurrentAddress(s);
            }).EnableCallContextPropagation();
            services.AddGrpcClient<Counter.CounterClient>((s, o) =>
            {
                o.Address = GetCurrentAddress(s);
            }).EnableCallContextPropagation();

            static Uri GetCurrentAddress(IServiceProvider serviceProvider)
            {
                // Get the address of the current server from the request
                var context = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext;
                if (context == null)
                {
                    throw new InvalidOperationException("Could not get HttpContext.");
                }
                return new Uri($"{context.Request.Scheme}://{context.Request.Host.Value}");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<GreeterService>();
                endpoints.MapGrpcService<CounterService>();
                endpoints.MapGrpcService<RacerService>();
                endpoints.MapGrpcService<AggregatorService>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
