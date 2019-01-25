using Sample.Utilities.Framework;
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

namespace Sample.WinformClient.Tests
{
    public partial class PleaseWaitTest : Form
    {
        private int timeout = 3000;
        public PleaseWaitTest()
        {
            InitializeComponent();
        }

        private void PleaseWaitTest_Load(object sender, EventArgs e)
        {
            //Task.Factory.StartNew(() =>
            //{
            //    PleaseWait pleaseWait = new PleaseWait(this, "加载中...");
            //    pleaseWait.Show();
            //    RunTimeConsumingTask();
            //    pleaseWait.Close();
            //});

        }

        private void RunTimeConsumingTask()
        {
            Thread.Sleep(5000);
        }

        private async void btnRunTask_Click(object sender, EventArgs e)
        {
            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            PleaseWait pleaseWait = new PleaseWait(this, new Size(this.Width, this.Height), "正在获取数据...", new Font("微软雅黑", 18), Properties.Resources.Dual_Ring_1s_200px, new Size(75, 75));
            pleaseWait.Show();
            var t1 = Task.Factory.StartNew(delegate
            {
                RunTimeConsumingTask();

            }, token, TaskCreationOptions.None, backgroundScheduler);
            if (await Task.WhenAny(t1, Task.Delay(timeout)) == t1)
            {
                await t1.ContinueWith(delegate
                {
                    label1.Text = "成功获取到数据.";
                    pleaseWait.Close();
                }, token, TaskContinuationOptions.None, uiScheduler);
            }
            else
            {
                label1.Text = "请求超时.";
                pleaseWait.Close();
            }
        }
    }
}
