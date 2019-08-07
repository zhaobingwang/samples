using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Infrastructure.Data;
using Sample.NetCore.Infrastructure.Interfaces;
using Sample.NetCore.Web.Models;

namespace Sample.NetCore.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                try
                {
                    //var context = service.GetRequiredService<MSSQLContext>();
                    var context = service.GetRequiredService<PostgreSQLContext>();
                    context.Database.Migrate();
                    SeedData.Initialize(service);

                    var repository = service.GetService<ITodoItemRepository>();
                    InitializeDatabaseAsync(repository).Wait();
                }
                catch (Exception ex)
                {
                    var logger = service.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.others.json",
                    optional: false,
                    reloadOnChange: false);
            })
            .UseStartup<Startup>();



        private static async Task InitializeDatabaseAsync(ITodoItemRepository repository)
        {
            var sessionList = await repository.ListAsync();
            if (!sessionList.Any())
            {
                await repository.AddAsync(GetTestTodos());
            }
        }

        private static TodoItem GetTestTodos()
        {
            var todo = new TodoItem()
            {
                Name = "测试",
                IsComplete = false,
                CreateTime = DateTimeOffset.UtcNow,
                ModifyTime = DateTimeOffset.UtcNow,
            };
            var step1 = new TodoItemStep()
            {
                Index = 1,
                Name = "步骤1"
            };
            var step2 = new TodoItemStep()
            {
                Index = 1,
                Name = "步骤2"
            };

            todo.AddStep(step1);
            todo.AddStep(step2);

            return todo;
        }
    }
}
