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
using Sample.Utilities.Framework.WinformOperation;

namespace Sample.Winform.MQ
{
    public partial class RabbitMQOperation : Form
    {
        Logger logger;
        public RabbitMQOperation()
        {
            InitializeComponent();
            logger = new Logger(rtxLogs);
        }

        private void PublishMessage_Load(object sender, EventArgs e)
        {
            MQManager mqManager = new MQManager();
            var result = mqManager.GetQueueReadyMessageCount("click_house");

            logger.LogInfo($"消费者数量：{result.consumerCount}");
            logger.LogInfo($"消息数量：{result.messageCount}");
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
