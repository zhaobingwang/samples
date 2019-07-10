using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Utilities.Framework.RabbitMQOperation
{
    public class MQManager
    {
        private static readonly string RabbitMQUri = null;
        static MQManager()
        {
            RabbitMQUri = ConfigurationManager.ConnectionStrings["rabbitmq.conn"].ConnectionString;
        }

        /// <summary>
        /// 获取队列中Ready的消息个数
        /// </summary>
        /// <param name="queueName"></param>
        /// <returns></returns>
        public (uint messageCount, uint consumerCount) GetQueueReadyMessageCount(string queueName)
        {
            uint readyMessageCount = default;
            uint consumerCount = default;
            var factory = new ConnectionFactory() { Uri = new Uri(RabbitMQUri) };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var response = channel.QueueDeclarePassive(queueName);
                    readyMessageCount = response.MessageCount;
                    consumerCount = response.ConsumerCount;
                }
            }
            return (readyMessageCount, consumerCount);
        }
    }
}
