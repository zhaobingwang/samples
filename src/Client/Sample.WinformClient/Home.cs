using Sample.WinformClient.Others;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnWinformTimer_Click(object sender, EventArgs e)
        {
            WinformTimer winformTimer = new WinformTimer();
            winformTimer.ShowDialog();
            winformTimer.Dispose();
        }
    }
}
