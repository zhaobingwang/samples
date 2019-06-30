using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sample.Utilities.Framework.RabbitMQOperation;

namespace Sample.Winform.MQ
{
    public partial class PublishMessage : Form
    {
        public PublishMessage()
        {
            InitializeComponent();
        }

        private void PublishMessage_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Publish();
                });
            }
        }

        public void Publish(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Producer.PublishTestMessage($"消息{i}");
            }
        }
        public void Publish()
        {
            int index = 1;
            while (true)
            {
                Producer.PublishClickHouseMessage($"消息{index}");
                index++;
                Thread.Sleep(10);
            }
        }
    }
}
