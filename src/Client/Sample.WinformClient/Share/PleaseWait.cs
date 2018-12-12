using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient.Share
{
    /// <summary>
    /// 耗时任务执行中使用此类来显示友好提示
    /// </summary>
    public class PleaseWait
    {
        private Panel pnlContainer = null;
        private Label lblMessage = null;
        private PictureBox picLoading;

        private Form _parent = null;
        private string _message = null;

        public PleaseWait(Form parent, string message)
        {
            _parent = parent;
            _message = message;
        }

        public void Show()
        {
            CreateMessage();
        }
        public void Refresh(string message)
        {
            if (lblMessage != null)
                lblMessage.Text = message;
            else
                throw new Exception($"{nameof(lblMessage)} is undefined");
        }
        public void Close()
        {
            if (picLoading != null)
            {
                picLoading.Dispose();
                picLoading = null;
            }
            if (lblMessage != null)
            {
                lblMessage.Dispose();
                lblMessage = null;
            }
            if (pnlContainer != null)
            {
                pnlContainer.Controls.Clear();
                pnlContainer.Dispose();
                pnlContainer = null;
            }
        }

        private void CreateMessage()
        {
            #region message container
            pnlContainer = new Panel();
            pnlContainer.Width = _parent.Width;
            pnlContainer.Height = _parent.Height / 2;
            pnlContainer.BorderStyle = BorderStyle.None;
            #endregion

            #region message of label
            lblMessage = new Label();
            lblMessage.Text = _message;
            lblMessage.AutoSize = true;
            lblMessage.Width = _parent.Width - 100;
            lblMessage.MaximumSize = new Size(_parent.Width - 100, 0);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Font = new Font("微软雅黑", 18);
            lblMessage.BackColor = Color.Transparent;
            #endregion

            #region picture of loading
            picLoading = new PictureBox();
            picLoading.Image = Properties.Resources.Pacman_1s_200px;
            picLoading.Size = new Size(75, 75);
            picLoading.BorderStyle = BorderStyle.None;
            picLoading.SizeMode = PictureBoxSizeMode.StretchImage;
            #endregion

            // 添加控件
            pnlContainer.Controls.Add(lblMessage);   // 向容器中添加消息
            pnlContainer.Controls.Add(picLoading);   // 向容器中添加加载动画
            _parent.Controls.Add(pnlContainer);   // 向窗体中添加容器

            // 设置容器位置（在父窗体中添加完成后设置才有效）
            pnlContainer.Left = 0;
            pnlContainer.Top = (_parent.Height - pnlContainer.Height) / 2;
            pnlContainer.BringToFront();

            // 设置加载动画位置（在父窗体中添加完成后设置才有效）
            picLoading.Left = (pnlContainer.Width - picLoading.Width) / 2;
            picLoading.Top = (pnlContainer.Height - lblMessage.Height - picLoading.Height - 20) / 2;

            // 设置文本消息位置（在父窗体中添加完成后设置才有效）
            lblMessage.Top = picLoading.Top + picLoading.Height + 10;
            lblMessage.Left = (pnlContainer.Width - lblMessage.Width) / 2;

        }
    }
}
