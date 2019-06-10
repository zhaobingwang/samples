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
    public partial class LayerSample : Form
    {
        public LayerSample()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Layer.ShowMessage("这是一个测试内容AAAAAAAAAAAAAAAAAAAAABBBBBBBBBBBBBCCCCCCCCCCCC啊啊啊啊啊啊啊啊啊啊啊啊", pnlMain, pnlMain.Width);
        }

        private void BtnAlert_Click(object sender, EventArgs e)
        {
            Layer.Alert(pnlMain, "这是一个测试内容", pnlMain.Width);
        }
    }
}
