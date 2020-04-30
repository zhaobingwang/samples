using Nest;
using System;
using System.Text.Json;
namespace ElasticSearchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var index = "app.client.demo";
            var node = new Uri("http://localhost:9200");
            var uname = "elastic";
            var upw = "123456";
            var settings = new ConnectionSettings(node);
            settings.BasicAuthentication(uname, upw);
            var client = new ElasticClient(settings);

            var sample = new Sample
            {
                Id = 6,
                RegTime = DateTime.UtcNow,
                Message = "test msg"
            };

            var response = client.Index(sample, idx => idx.Index(index));

            var doc = client.Get<Sample>(1, idx => idx.Index(index));
            Console.WriteLine(JsonSerializer.Serialize(doc.Source));

            var searchDoc = client.Search<Sample>(s => s.Index(index)
            .From(0)
            .Size(10)
            .Query(q => q.Term(t => t.Message, "testmsg") || q.Match(mq => mq.Field(f => f.Message)
                   .Query("test")))
            );
            Console.WriteLine(JsonSerializer.Serialize(searchDoc.Documents));
            var a = 1;
        }
    }

    class Sample
    {
        public int Id { get; set; }
        public DateTime RegTime { get; set; }
        public string Message { get; set; }
    }
}
