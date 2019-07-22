using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.Infrastructure
{
    public interface IProducer
    {
        void Publish(string message);
        void Publish(string exchangeName, string routingKey, string message);
    }
}
