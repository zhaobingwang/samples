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
using System.Diagnostics;
using CodeSnippets.Infrastructure.Dto;
using DapperMSSql = CodeSnippets.Infrastructure.Dapper.MSSqlServer;

namespace CodeSnippets.ConsoleApp
{
    class User
    {
        public int Id { get; set; }
    }
    class Program
    {
        public static ILoggerFactory LoggerFactory;
        //public static IConfigurationRoot Configuration;
        public static IConfigurationRoot Configuration;
        static async Task Main(string[] args)
        {

            var services = new ServiceCollection();
            // Set up configuration sources.
            var builder = new ConfigurationBuilder().SetBasePath(Path.Combine(AppContext.BaseDirectory)).AddJsonFile("appsettings.json", optional: true);
            Configuration = builder.Build();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddEntityFrameworkSqlite()
                .AddDbContext<SqliteEFContext>(options => options.UseSqlite(Configuration.GetConnectionString("sqlite")));
            services.AddScoped<ISampleEntityRepository, SampleEntityRepository>();

            #region Dapper-MSSqlServer
            services.AddTransient<DapperMSSql.IBaseRepository, DapperMSSql.BaseRepository>();
            #endregion

            var serviceProvider = services.BuildServiceProvider();
            var sampleEntityService = serviceProvider.GetRequiredService<ISampleEntityRepository>();
            var baseRepository = serviceProvider.GetRequiredService<DapperMSSql.IBaseRepository>();


            Stopwatch stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();

                #region emoji
                //Console.OutputEncoding = Encoding.Unicode;

                //var json = await File.ReadAllTextAsync("static/emoji/face-smiling.json");
                //var emojis = JsonOperator.ToObject<FaceSmilingDto>(json);
                //foreach (var emoji in emojis.FaceSmiling)
                //{
                //    Console.Write(Emoji.EmojiCodeToUTF16String(emoji.Code));
                //} 
                #endregion



                //var aa = baseRepository.Get();
                await new AccessAPI().Run();

                //Console.WriteLine($"\nElapsed time:{stopwatch.ElapsedMilliseconds}ms");
                stopwatch.Stop();
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
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
                Console.WriteLine("end");
            }
        }
    }
}
