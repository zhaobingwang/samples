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
using WinFormTimer = System.Windows.Forms.Timer;

namespace Sample.WinformClient.DesignPatterns
{
    public partial class ObserverSample : Form
    {
        Logger logger;

        private WinFormTimer timerSmartWatchClock;

        DateTime alarmTime;
        public ObserverSample()
        {
            InitializeComponent();

            logger = new Logger(ProcessLogs);

            alarmTime = DateTime.Now.AddSeconds(10);

            timerSmartWatchClock = new WinFormTimer();
            timerSmartWatchClock.Tick += SmartWatchClock_Tick;
            timerSmartWatchClock.Interval = 1000;
            timerSmartWatchClock.Start();
            

        }

        private void SmartWatchClock_Tick(object sender, EventArgs e)
        {
            SmartWatchClock.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void ObserverSample_Load(object sender, EventArgs e)
        {
            logger.Info($"闹钟时间设置为：{alarmTime}");
            RunInBackgournd(alarmTime);
        }


        private void RunInBackgournd(DateTime? alarmTime)
        {
            if (alarmTime.HasValue)
            {
                var cancelToken = new CancellationTokenSource();
                var task = new Task(() =>
                {
                    while (!cancelToken.IsCancellationRequested)
                    {

                        if (DateTime.Now >= alarmTime.Value)
                        {
                            //闹铃时间到了
                            Alarm();
                            cancelToken.Cancel();
                        }
                        else
                        {
                            //BeginInvoke(new MethodInvoker(() =>
                            //{
                                logger.Info($"现在时间是：{DateTime.Now}");
                            //}));

                        }
                        Task.Delay(1000);
                        cancelToken.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                    }
                }, cancelToken.Token, TaskCreationOptions.LongRunning);
                task.Start();
            }
        }

        private void Alarm()
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                logger.Info("闹钟响...");
            }));

        }
    }
}
