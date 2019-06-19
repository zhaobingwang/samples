using Sample.Winform.UIModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Winform
{
    public partial class PleaseWaitSample : Form
    {
        public PleaseWaitSample()
        {
            InitializeComponent();
        }

        PleaseWait pleaseWait;
        private void PleaseWaitSample_Load(object sender, EventArgs e)
        {
            pleaseWait = new PleaseWait(pnlMain, Properties.Resources.loading_01, "正在加载中...");
            pleaseWait.Show();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (pleaseWait != null)
            {
                pleaseWait.Refresh("现在显示的是更新的等待消息...");
            }
        }
    }
}
