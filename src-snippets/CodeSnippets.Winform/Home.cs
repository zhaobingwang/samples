using CodeSnippets.Winform.UIModule;
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

namespace CodeSnippets.Winform
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            PleaseWait pleaseWait = new PleaseWait(pnlLoading, Properties.Resources.loading_01, "正在加载第一个任务...");
            pleaseWait.Show();

            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task.Factory.StartNew(delegate
            {
                Thread.Sleep(2000);
                cts.Cancel();
                pleaseWait.Close();
            }, token, TaskCreationOptions.None, backgroundScheduler)
            .ContinueWith(delegate
            {
                pleaseWait.Refresh("正在加载第二个任务");
            }, token, TaskContinuationOptions.None, uiScheduler)
            .ContinueWith(delegate
            {
                Thread.Sleep(2000);
            }, token, TaskContinuationOptions.None, backgroundScheduler)
            .ContinueWith(delegate
            {
                pleaseWait.Refresh("正在加载第三个任务");
                pleaseWait.Close();
            }, token, TaskContinuationOptions.None, uiScheduler);
        }
    }
}
