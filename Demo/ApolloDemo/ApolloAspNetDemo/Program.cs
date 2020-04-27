using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Com.Ctrip.Framework.Apollo.Enums;
using Com.Ctrip.Framework.Apollo.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApolloAspNetDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LogManager.UseConsoleLogging(Com.Ctrip.Framework.Apollo.Logging.LogLevel.Trace);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, builder) =>
                 {
                     builder
                     .AddApollo(builder.Build().GetSection("apollo"))
                     //.AddDefault(ConfigFileFormat.Xml)
                     //.AddDefault(ConfigFileFormat.Json)
                     //.AddDefault(ConfigFileFormat.Yml)
                     //.AddDefault(ConfigFileFormat.Yaml)
                     .AddDefault()
                     .AddNamespace("development.common");
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
