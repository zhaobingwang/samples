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
            logger.LogImportantInfo($"闹钟时间设置为：{alarmTime}");
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
            AlarmClock alarmClock = new AlarmClock();
            BedsideLamp turnOnTheBedsideLamp = new BedsideLamp(logger, "床头灯", alarmClock);
            Curtains curtains = new Curtains(logger, "窗帘", alarmClock);
            Speaker speaker = new Speaker(logger, "音响", alarmClock);
            alarmClock.DoSomething("闹钟响了，准备起床。");
        }
    }

    #region 订阅了闹钟响铃的设备
    /// <summary>
    /// 床头灯
    /// </summary>
    public class BedsideLamp
    {
        private string id;
        private Logger _logger;
        public BedsideLamp(Logger logger, string ID, AlarmClock pub)
        {
            _logger = logger;
            id = ID;
            pub.AlarmCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            _logger.LogImportantInfo($"【{id}】 收到消息: {e.Message}");
            _logger.LogImportantInfo($"【{id}】 已打开床头灯");
        }
    }
    /// <summary>
    /// 窗帘
    /// </summary>
    public class Curtains
    {
        private string id;
        private Logger _logger;
        public Curtains(Logger logger, string ID, AlarmClock pub)
        {
            _logger = logger;
            id = ID;
            pub.AlarmCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            _logger.LogImportantInfo($"【{id}】 收到消息: {e.Message}");
            _logger.LogImportantInfo($"【{id}】 已打开窗帘");
        }
    }
    /// <summary>
    /// 音箱
    /// </summary>
    public class Speaker
    {
        private string id;
        private Logger _logger;
        public Speaker(Logger logger, string ID, AlarmClock pub)
        {
            _logger = logger;
            id = ID;
            pub.AlarmCustomEvent += HandleCustomEvent;
        }
        void HandleCustomEvent(object sender, CustomEventArgs e)
        {
            _logger.LogImportantInfo($"【{id}】 收到消息: {e.Message}");
            _logger.LogImportantInfo($"【{id}】 开始播放音乐");
        }
    }
    #endregion

    /// <summary>
    /// 闹钟类
    /// </summary>
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
                //e.Message += $" at {DateTime.Now}";
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
