using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Compression;
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
            // 为所有服务配置选项
            // 更多服务端gRPC配置，详见：https://docs.microsoft.com/zh-cn/aspnet/core/grpc/configuration?view=aspnetcore-3.0
            services.AddGrpc(option =>
            {
                option.MaxSendMessageSize = 5 * 1024 * 1024;    // 可从服务器发送的最大消息大小（以字节为单位）。 尝试发送超过配置的最大消息大小的消息将导致异常。 默认值：null
                option.MaxReceiveMessageSize = 2 * 1024 * 1024; // 服务器可接收的最大消息大小（以字节为单位）。 如果服务器收到的消息超过此限制，则会引发异常。 增大此值可使服务器接收更大的消息，但会对内存消耗产生负面影响。 默认4 MB
                option.EnableDetailedErrors = true; // 如果true为，则在服务方法中引发异常时，详细的异常消息将返回到客户端。 默认值为 false。 设置EnableDetailedErrors 为true可以泄露敏感信息。
                option.CompressionProviders.Add(new GzipCompressionProvider(CompressionLevel.Optimal));   // 用于压缩和解压缩消息的压缩提供程序的集合。 可以创建自定义压缩提供程序并将其添加到集合中。 默认配置的提供程序支持gzip压缩。 默认值：Gzip
                option.ResponseCompressionAlgorithm = null; // 压缩算法用于压缩从服务器发送的消息。 该算法必须与CompressionProviders中的压缩提供程序匹配。 为了使算法压缩响应，客户端必须通过在grpc-accept标头中发送来指示它支持该算法。 默认值：null
                option.ResponseCompressionLevel = CompressionLevel.Optimal; // 用于压缩从服务器发送的消息的压缩级别。 默认值：null
            });

            // 单个服务的选项可替代和中AddGrpc提供的全局选项，可以使用AddServiceOptions<TService>以下方法配置：
            //services.AddGrpc().AddServiceOptions<GreeterService>(options =>
            //{
            //    options.MaxReceiveMessageSize = 2 * 1024 * 1024; // 2 MB
            //    options.MaxSendMessageSize = 5 * 1024 * 1024; // 5 MB
            //});


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
