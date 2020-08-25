using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string dbName = "logs";
            string collcetionName = "log.exceptions";
            var setting = new MongoClientSettings
            {
                Server = new MongoServerAddress("127.0.0.1", 27017),
                UseTls = false,
                ApplicationName = "Demo.Client.NetCore",
            };
            var client = new MongoClient(setting);
            IMongoDatabase db = client.GetDatabase(dbName);
            await db.CreateCollectionAsync(collcetionName);

            var collection = db.GetCollection<LogModel>(collcetionName);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (true)
            {
                Console.WriteLine("Please input log code: ");
                var input = Console.ReadLine();
                if (input == "n")
                    break;
                try
                {
                    int i = 0;
                    int b = 10 / i;
                }
                catch (Exception ex)
                {
                    var logModel = new LogModel
                    {
                        Code = input,
                        ExType = ex.GetType().Name,
                        Message = ex.Message,
                        Details = ex.ToString(),
                        LogTime = DateTime.UtcNow
                    };
                    sw.Restart();
                    await collection.InsertOneAsync(logModel);
                    sw.Stop();
                    Console.WriteLine(sw.ElapsedMilliseconds);
                }
            }

            List<LogModel> logs = new List<LogModel>();
            for (int i = 0; i < 1000000; i++)
            {
                var logModel = new LogModel
                {
                    Code = "A1000" + i % 10,
                    ExType = "DivideByZeroException",
                    Message = "Attempted to divide by zero.",
                    Details = "System.DivideByZeroException: Attempted to divide by zero.\r\n   at MongoDBDemo.Program.Main(String[] args) in C:\\repository\\sample\\Demo\\MongoDBDemo\\MongoDBDemo\\Program.cs:line 41",
                    LogTime = DateTime.UtcNow
                };
                logs.Add(logModel);
            }
            await collection.InsertManyAsync(logs);
            //var a10002 = await collection.FindAsync<LogModel>(x => x.Code == "A10001");
            //var logList = await a10002?.ToListAsync();
            //Console.WriteLine(logList.Count);
            //foreach (var log in logList)
            //{
            //    Console.WriteLine($"{log.Id}\t{log.LogTime}\t{log.ExType}\t{log.Message}\t{log.Details}");
            //}

            Console.WriteLine("end");
        }

        static void TriggerException()
        {

        }
    }

    class LogModel
    {
        public ObjectId Id { get; set; }
        public string Code { get; set; }
        public string ExType { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        //[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LogTime { get; set; }
    }
}
