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
    public partial class TemporaryPage : Form
    {
        public TemporaryPage()
        {
            InitializeComponent();
        }

        string val = "";
        private void Button1_Click(object sender, EventArgs e)
        {
            var random = new Random().Next(0, 10).ToString();
            val += random;
            label1.Text += random;
            btnText.Text += "*";
        }

        private void BtnText_TextChanged(object sender, EventArgs e)
        {
            if (btnText.Tag != null)
                label1.Text = btnText.Tag.ToString();
        }

        private void TemporaryPage_Load(object sender, EventArgs e)
        {
            label1.Text = "";
            SoftKeyboard softKeyboard = new SoftKeyboard(btnText, '*');
            softKeyboard.BorderStyle = BorderStyle.None;
            pnlSoftKeyBoard.Controls.Add(softKeyboard);

        }
    }
}
