using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sample.Utilities.Framework;

namespace Sample.WinformClient.Tests
{
    public partial class LayerTest : Form
    {
        public LayerTest()
        {
            InitializeComponent();
        }

        private void btnAlert_Click(object sender, EventArgs e)
        {
            Layer.Alert(pnlContent, "发生错误", new Size(300, 100),2000);
        }
    }
}
