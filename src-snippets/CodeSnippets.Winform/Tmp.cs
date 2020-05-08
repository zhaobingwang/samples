using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSnippets.Winform
{
    public partial class Tmp : Form
    {
        public Tmp()
        {
            InitializeComponent();
        }

        private void btnThrowException_Click(object sender, EventArgs e)
        {
            throw new Exception("hhhh");
        }

        private async void btnThrowTaskException_Click(object sender, EventArgs e)
        {
            var task = Task.Run(() =>
            {
                int a = 0;
                int b = 10 / a;
            });
            await task;
        }
    }
}
