using Hangfire;
using Hangfire.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient.JobScheduling
{
    public partial class HangFireSample : Form
    {
        public HangFireSample()
        {
            InitializeComponent();
        }

        private void HangFireSample_Load(object sender, EventArgs e)
        {
            RecurringJob.AddOrUpdate(() => DoSomething(), "0/1 * * * * ? *");
        }
        public void DoSomething()
        {
            label1.Text = DateTime.Now.ToString();
        }
    }
}
