using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.Infrastructure
{
    public class Producer : IProducer
    {
        //public IConfiguration Configuration { get; }
        public string RabbitMQUri { get; private set; }
        public Producer(IConfiguration configuration)
        {
            //Configuration = configuration;
            RabbitMQUri = configuration.GetConnectionString("RabbitMQ-Uri");
        }

        public void Publish(string message)
        {
            throw new NotImplementedException();
        }

        public void Publish(string exchangeName, string routingKey, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                return;
            var factory = new ConnectionFactory() { Uri = new Uri(RabbitMQUri) };
            using (var conncetion = factory.CreateConnection())
            {
                using (var channel = conncetion.CreateModel())
                {
                    channel.BasicPublish(
                        exchange: exchangeName,
                        routingKey: routingKey,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(message)
                    );
                }
            }
        }

    }
}
