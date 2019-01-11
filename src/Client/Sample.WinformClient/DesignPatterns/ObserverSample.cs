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
    /*
     * 1 智能手表检测到您已睡醒（为了方便演示，本示例使用闹钟替代，闹钟响表示智能手表检测到您已睡醒）
     * 2.1 打开床头灯
     * 2.2 打开窗帘
     * 2.3 播放音乐
     */
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
            TurnOnTheAlarm(alarmTime);
        }


        private void TurnOnTheAlarm(DateTime? alarmTime)
        {
            if (!alarmTime.HasValue)
            {
                return;
            }
            var cancelToken = new CancellationTokenSource();
            var task = new Task(() =>
            {
                while (!cancelToken.IsCancellationRequested)
                {

                    if (DateTime.Now >= alarmTime.Value)
                    {
                        // 闹铃时间到了
                        Alarm();
                        cancelToken.Cancel();
                    }
                    else
                    {
                        logger.Info($"现在时间是：{DateTime.Now}");
                    }
                    cancelToken.Token.WaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                }
            }, cancelToken.Token, TaskCreationOptions.LongRunning);
            task.Start();
        }

        private void Alarm()
        {
            logger.Info("闹钟响...");
            AlarmClock alarmClock = new AlarmClock();
            alarmClock.AlarmCustomEvent += TurnOnTheBedsideLamp;
            alarmClock.AlarmCustomEvent += OpenThecurtains;
            alarmClock.AlarmCustomEvent += PlayingMusic;
        }
        private void TurnOnTheBedsideLamp(object sender, CustomEventArgs e)
        {
            logger.Info("打开床头灯");
        }
        private void OpenThecurtains(object sender, CustomEventArgs e)
        {
            logger.Info("打开窗帘");
        }
        private void PlayingMusic(object sender, CustomEventArgs e)
        {
            logger.Info("播放音乐");
        }
    }

    public class AlarmClock
    {
        public event EventHandler<CustomEventArgs> AlarmCustomEvent;

        public void DoSomething(string s)
        {
            OnAlarmCustomEvent(new CustomEventArgs(s));
        }
        protected virtual void OnAlarmCustomEvent(CustomEventArgs e)
        {
            EventHandler<CustomEventArgs> handler = AlarmCustomEvent;
            if (handler != null)
            {
                e.Message += $" at {DateTime.Now}";
                handler(this, e);
            }
        }
    }

    public delegate void EventHandler(object sender, EventArgs e);

    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            message = s;
        }
        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }
    }
}
