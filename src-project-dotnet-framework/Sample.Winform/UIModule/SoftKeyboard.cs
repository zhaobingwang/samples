using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace Sample.Winform.UIModule
{
    public partial class SoftKeyboard : UserControl
    {
        Button _button = null;
        public SoftKeyboard()
        {

        }
        char _hideStr;
        public SoftKeyboard(Button button, char hideStr)
        {
            InitializeComponent();
            if (button == null)
            {
                return;
            }
            _button = button;
            _hideStr = hideStr;
        }

        private string tmp = "";
        private void InputContent(string input)
        {
            if (_button != null)
            {
                tmp += input;
                _button.Tag = tmp;
                _button.Text = $"{_button.Text}{input}";
                Delay();
            }
        }


        private void Delay()
        {
            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task.Factory.StartNew(delegate
            {
                Thread.Sleep(300);
            }, token, TaskCreationOptions.None, backgroundScheduler)
                .ContinueWith(delegate
                {
                    var len = tmp.Length;
                    _button.Text = _hideStr.ToString().PadRight(len, _hideStr);
                }, token, TaskContinuationOptions.None, uiScheduler);
        }


        private void butNum1_Click(object sender, EventArgs e)
        {
            InputContent("1");
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            InputContent("2");
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            InputContent("3");
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            InputContent("4");
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            InputContent("5");
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            InputContent("6");
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            InputContent("7");
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            InputContent("8");
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            InputContent("9");
        }

        private void btnNum0_Click(object sender, EventArgs e)
        {
            InputContent("0");
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            InputContent(".");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;

            Task.Factory.StartNew(delegate
            {
                Thread.Sleep(200);
            }, token, TaskCreationOptions.None, backgroundScheduler)
                .ContinueWith(delegate
                {
                    if (_button != null)
                    {
                        _button.Tag = "";
                        tmp = "";

                        _button.Text = "";
                        _button.Focus();
                    }
                }, token, TaskContinuationOptions.None, uiScheduler);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_button != null && _button.Text.Length > 0)
            {
                tmp = tmp.Substring(0, tmp.Length - 1);
                _button.Tag = tmp;
                _button.Text = _button.Text.Substring(0, _button.Text.Length - 1);
            }
        }
    }
}
