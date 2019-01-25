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

namespace Sample.WinformClient.Others
{
    public partial class WinformTimer : Form
    {
        System.Windows.Forms.Timer timer;
        public WinformTimer()
        {
            InitializeComponent();
        }

        private void WinformTimer_Load(object sender, EventArgs e)
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick; ;
            timer.Interval = 2000;
            timer.Start();
            Task.Factory.StartNew(() =>
            {


            });

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Thread.Sleep(3000);
            label1.Text = $"{DateTime.Now}";
            //MessageBox.Show("a");
            //NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
            //logger.Info($"{DateTime.Now}");
        }

        private void WinformTimer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer!=null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
        }
    }
}
