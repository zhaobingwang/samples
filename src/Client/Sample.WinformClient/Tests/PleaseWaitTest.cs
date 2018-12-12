using Sample.WinformClient.Share;
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
            Thread.Sleep(3000);
        }

        private void btnRunTask_Click(object sender, EventArgs e)
        {
            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            PleaseWait pleaseWait = new PleaseWait(this, "加载中...");
            pleaseWait.Show();
            Task.Factory.StartNew(delegate
            {
                RunTimeConsumingTask();

            }, token, TaskCreationOptions.None, backgroundScheduler).
            ContinueWith(delegate
            {
                label1.Text = "成功获取到数据.";
                pleaseWait.Close();
            }, token, TaskContinuationOptions.None, uiScheduler);
        }
    }
}
