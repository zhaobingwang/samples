using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.NetCore.Infrastructure
{
    public interface IConsumer
    {
        void StartConsume();
        void StopConsume();
        void MessageReceived(object sender, EventArgs args);
    }
}
