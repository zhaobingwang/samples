using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Utilities.Framework
{
    public static class Layer
    {
        public async static void Alert(Control parent, string message, Size layerSize, int displayTime = 2000)
        {
            Panel pnlContainer = null;
            Label lblMessage = null;
            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();

            #region message container
            pnlContainer = new Panel();
            pnlContainer.Size = layerSize;
            pnlContainer.BorderStyle = BorderStyle.None;
            pnlContainer.BackColor = Color.FromArgb(102, 102, 102);
            #endregion

            #region message of label
            lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.AutoSize = true;
            lblMessage.Width = pnlContainer.Width;
            lblMessage.MaximumSize = new Size(pnlContainer.Width, 0);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Font = new Font("微软雅黑", 18);
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = Color.White;
            #endregion

            // 添加控件
            pnlContainer.Controls.Add(lblMessage);   // 向容器中添加消息
            parent.Controls.Add(pnlContainer);   // 向窗体中添加容器

            // 设置容器位置（在父窗体中添加完成后设置才有效）
            pnlContainer.Left = (parent.Width - pnlContainer.Width) / 2;
            pnlContainer.Top = (parent.Height - pnlContainer.Height) / 2;
            pnlContainer.BringToFront();

            // 设置文本消息位置（在父窗体中添加完成后设置才有效）
            lblMessage.Top = (pnlContainer.Height - lblMessage.Height) / 2;
            lblMessage.Left = (pnlContainer.Width - lblMessage.Width) / 2;

            var t2 = Task.Delay(displayTime);
            await Task.WhenAll(t2);

            pnlContainer.Controls.Clear();
            pnlContainer.Dispose();
            pnlContainer = null;
        }

    }
}
