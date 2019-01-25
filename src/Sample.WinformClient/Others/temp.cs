using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient.Others
{
    public partial class temp : Form
    {
        public temp()
        {
            InitializeComponent();
        }

        private void temp_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    if (!DoSomething(true))
                    {
                        BeginInvoke(new MethodInvoker(() =>
                        {
                            label1.Text = "failed";
                        }));
                    }
                    else
                    {
                        BeginInvoke(new MethodInvoker(() =>
                        {
                            label1.Text = "success";
                        }));
                    }
                }
                catch (Exception ex)
                {
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        label1.Text = $"{ex.Message}";
                    }));
                }
            });
            label1.Text = "end";
        }
        private bool DoSomething(bool isThrow)
        {
            if (isThrow)
            {
                throw new Exception("nothing.");
            }
            return true;
        }
    }
}
