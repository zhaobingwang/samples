using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.Infrastructure
{
    public abstract class Consumer : IConsumer
    {
        //public IConfiguration Configuration { get; }
        protected string RabbitMQUri { get; private set; } = null;
        protected bool AutoAck { get; private set; } = false;
        protected string QueueName { get; private set; } = null;

        protected ConnectionFactory Factory = null;
        protected IConnection Connection = null;
        protected IModel Chanel = null;
        protected EventingBasicConsumer BasicConsumer = null;
        public Consumer(IConfiguration configuration)
        {
            //Configuration = configuration;
            RabbitMQUri = configuration.GetConnectionString("RabbitMQ-Uri");
        }
        //public Consumer(IOptions<TOptions> options, string queueName, bool autoAck = false)
        //{

        //}
        public Consumer(string uri, string queueName, bool autoAck = false)
        {
            RabbitMQUri = uri;
            QueueName = queueName;
            AutoAck = autoAck;
            Factory = new ConnectionFactory() { Uri = new Uri(RabbitMQUri) };
            Connection = Factory.CreateConnection();
            Chanel = Connection.CreateModel();
            Chanel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            BasicConsumer = new EventingBasicConsumer(Chanel);
        }
        public Consumer(IConfiguration configuration, string queueName, bool autoAck = false) : this(configuration)
        {
            QueueName = queueName;
            AutoAck = autoAck;
            Factory = new ConnectionFactory() { Uri = new Uri(RabbitMQUri) };
            Connection = Factory.CreateConnection();
            Chanel = Connection.CreateModel();
            Chanel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            BasicConsumer = new EventingBasicConsumer(Chanel);
        }

        public void StartConsume()
        {
            BasicConsumer.Received += Consumer_Received;
            Chanel.BasicConsume(QueueName, AutoAck, BasicConsumer);
        }
        public void StopConsume()
        {
            try
            {
                if (Chanel != null && Chanel.IsOpen)
                {
                    Chanel.Close();
                }
                if (Connection != null && Connection.IsOpen)
                {
                    Connection.Close();
                }
            }
            catch (Exception)
            {
            }
        }
        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            string message = Encoding.UTF8.GetString(body);
            bool consumed = MessageConsume(message);
            if (!AutoAck)
            {
                if (consumed)
                {
                    Chanel.BasicAck(e.DeliveryTag, false);
                }
                else
                {
                    Chanel.BasicReject(e.DeliveryTag, true);
                }
            }
        }

        public void MessageReceived(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }

        public abstract bool MessageConsume(string msg);
    }
}
