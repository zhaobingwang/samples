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

        // 定义AggregateException 的事件委托
        static event EventHandler<AggregateExceptionArgs> AggregateExceptionCatched;
        private void Home_Load(object sender, EventArgs e)
        {
            PleaseWait pleaseWait = new PleaseWait(pnlLoading, Properties.Resources.loading_01, "正在加载第一个任务...");
            pleaseWait.Show();
            AggregateExceptionCatched += new EventHandler<AggregateExceptionArgs>(Program_AggregateExceptionCatched);

            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;


            Task.Factory.StartNew(delegate
            {
                try
                {
                    Thread.Sleep(2000);
                    ThrowTestException();
                    cts.Cancel();
                    pleaseWait.Close();
                }
                catch (Exception ex)
                {
                    cts.Cancel();
                    pleaseWait.Close();
                    AggregateExceptionArgs args = new AggregateExceptionArgs()
                    {
                        AggregateException = new AggregateException(ex)
                    };
                    // 使用主线程委托代理，处理子线程 异常
                    // 这种方式没有阻塞 主线程或其他线程
                    AggregateExceptionCatched?.Invoke(null, args);
                }
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

            //var complexTask = Task.WhenAll(task);
            //complexTask.ContinueWith()
        }

        private void ThrowTestException()
        {
            throw new Exception("这是一个用于测试的异常");
        }
        static void Program_AggregateExceptionCatched(object sender, AggregateExceptionArgs e)
        {
            string errorMessage = null;
            foreach (var item in e.AggregateException.InnerExceptions)
            {
                errorMessage += $"{item.Message}\n";
            }
            MessageBox.Show(errorMessage);
        }

        // 定义异常参数处理
        public class AggregateExceptionArgs : EventArgs
        {
            public AggregateException AggregateException { get; set; }
        }
    }
}
