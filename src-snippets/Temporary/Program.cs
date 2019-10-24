using CodeSnippets;
using CodeSnippets.Books.CSharp157;
using CodeSnippets.Issues;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Collections.Generic;
using CodeSnippets.CSharp;
using CodeSnippets.Infrastructure;
using CodeSnippets.ThirdParty;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using CodeSnippets.Infrastructure.Interfaces;
using CodeSnippets.Infrastructure.Repositories;

namespace Temporary
{
    class User
    {
        public int Id { get; set; }
    }


    class Program
    {
        public static ILoggerFactory LoggerFactory;
        public static IConfigurationRoot Configuration;
        static async Task Main(string[] args)
        {

            var services = new ServiceCollection();
            // Set up configuration sources.
            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("appsettings.json", optional: true);
            Configuration = builder.Build();

            services.AddEntityFrameworkSqlite()
                .AddDbContext<SqliteEFContext>(options => options.UseSqlite(Configuration.GetConnectionString("sqlite")));
            services.AddScoped<ISampleEntityRepository, SampleEntityRepository>();

            var serviceProvider = services.BuildServiceProvider();
            var sampleEntityService = serviceProvider.GetRequiredService<ISampleEntityRepository>();

            try
            {
                TaskIssues.ExceptionHandling();
            }
            catch (CustomException ex)
            {
                Console.WriteLine(ex);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("end");
            }
        }
    }
}
