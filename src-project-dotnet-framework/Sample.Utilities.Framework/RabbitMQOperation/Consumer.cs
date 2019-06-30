using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Utilities.Framework.RabbitMQOperation
{
    public abstract class Consumer
    {
        private static readonly string RabbitMQUri = null;

        /// <summary>
        /// 消费的队列名称
        /// </summary>
        private string QueueName = null;

        /// <summary>
        /// 是否自动应答，true:server发出信息之后不会等待消费者的ack就删除该信息了，false:server发出信息之后会等待消费者的ack
        /// In automatic acknowledgement mode, a message is considered to be successfully delivered immediately after it is sent.
        /// </summary>
        private bool AutoAck = false;

        protected ConnectionFactory factory = null;
        protected IConnection connection = null;
        protected IModel chanel = null;
        protected EventingBasicConsumer consumer = null;

        static Consumer()
        {
            RabbitMQUri = ConfigurationManager.ConnectionStrings["rabbitmq.conn"].ConnectionString;
        }

        public Consumer(string queueName, bool autoAck = false)
        {
            QueueName = queueName;
            AutoAck = autoAck;

            factory = new ConnectionFactory() { Uri = new Uri(RabbitMQUri) };
            //Factory.AutomaticRecoveryEnabled = false;如果设成false，会导致RabbitMQ服务器切换主备的时候不会重新链接
            connection = factory.CreateConnection();
            chanel = connection.CreateModel();
            chanel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            consumer = new EventingBasicConsumer(chanel);
        }
        public void StartConsume()
        {
            consumer.Received += MessageReceived;
            chanel.BasicConsume(QueueName, AutoAck, consumer);
        }

        public void StopConsume()
        {
            try
            {
                if (chanel != null && chanel.IsOpen)
                {
                    chanel.Close();
                }
                if (connection != null && connection.IsOpen)
                {
                    connection.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        private void MessageReceived(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            string message = Encoding.UTF8.GetString(body);
            bool consumed = MessageConsume(message);
            if (!AutoAck)
            {
                if (consumed)
                {
                    chanel.BasicAck(e.DeliveryTag, false);
                }
                else
                {
                    chanel.BasicReject(e.DeliveryTag, true);
                }
            }
        }

        public abstract bool MessageConsume(string msg);
    }
}
