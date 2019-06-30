using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Utilities.Framework.RabbitMQOperation
{
    public class Producer
    {
        /// <summary>
        /// test exchange
        /// </summary>
        public const string EXCHANGE_TEST = "test";

        /// <summary>
        /// test Routing Key
        /// </summary>
        public const string ROUTING_KEY_TEST_QUEUE = "test_queue";

        private static readonly string RabbitMQUri = null;

        static Producer()
        {
            RabbitMQUri = ConfigurationManager.ConnectionStrings["rabbitmq.conn"].ConnectionString;
        }

        private static void Publish(string exchangeName, string routingKey, string msg)
        {
            if (string.IsNullOrEmpty(msg))
            {
                return;
            }

            var factory = new ConnectionFactory() { Uri = new Uri(RabbitMQUri) };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.BasicPublish(
                        exchange: exchangeName,
                        routingKey: routingKey,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(msg)
                    );
                }
            }
        }

        public static void PublishTestMessage(string message)
        {
            Publish(EXCHANGE_TEST, ROUTING_KEY_TEST_QUEUE, message);
        }

        public static void PublishClickHouseMessage(string message)
        {
            Publish("", "", message);
        }
    }
}
