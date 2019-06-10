using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Winform.UIModule
{
    public class Layer
    {
        /// <summary>
        /// 在一个panel中显示消息
        /// </summary>
        /// <param name="message">待显示的文本信息内容</param>
        /// <param name="panel">Panel容器</param>
        /// <param name="labelWith">label宽度</param>
        /// <param name="font">字体</param>
        /// <param name="fontSize">字体大小</param>
        public static void ShowMessage(string message, Panel panel, int labelWith = 400, string font = "微软雅黑", int fontSize = 18)
        {
            panel.Controls.Clear();

            Label lblNoData = new Label();
            lblNoData.Text = message;
            lblNoData.AutoSize = true;
            lblNoData.Width = labelWith;
            lblNoData.MaximumSize = new Size(labelWith, 0);
            lblNoData.AutoSize = true;
            lblNoData.TextAlign = ContentAlignment.MiddleCenter;
            lblNoData.Font = new Font(font, fontSize);
            lblNoData.BackColor = Color.Transparent;

            panel.Controls.Add(lblNoData);
            lblNoData.Left = (panel.Width - lblNoData.Width) / 2;
            lblNoData.Top = (panel.Height - lblNoData.Height) / 2;
        }

        public static void Alert(Control parent, string message, int maxWidth, int displayTime = 2000)
        {
            Panel pnlContainer = null;
            Label lblMessage = null;

            #region message container
            pnlContainer = new Panel();
            //pnlContainer.Size = layerSize;
            pnlContainer.BorderStyle = BorderStyle.None;
            //pnlContainer.BackColor = Color.FromArgb(102, 102, 102);
            #endregion

            #region message of label
            lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.AutoSize = true;
            lblMessage.Width = pnlContainer.Width;
            lblMessage.MaximumSize = new Size(maxWidth, 0);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Font = new Font("微软雅黑", 18);
            lblMessage.BackColor = Color.Transparent;
            lblMessage.ForeColor = Color.White;
            lblMessage.Top = 10;
            #endregion

            // 添加控件
            pnlContainer.Controls.Add(lblMessage);   // 向容器中添加消息
            parent.Controls.Add(pnlContainer);   // 向窗体中添加容器

            // 设置容器位置（在父窗体中添加完成后设置才有效）
            pnlContainer.Width = lblMessage.Width;
            pnlContainer.Height = lblMessage.Height + 20;
            pnlContainer.Left = (parent.Width - pnlContainer.Width) / 2;
            pnlContainer.Top = (parent.Height - pnlContainer.Height) / 2;
            pnlContainer.BringToFront();

            // 设置文本消息位置（在父窗体中添加完成后设置才有效）
            lblMessage.Top = (pnlContainer.Height - lblMessage.Height) / 2;
            lblMessage.Left = (pnlContainer.Width - lblMessage.Width) / 2;

            // 之所以放在这里设置背景，是为了方式避免在部分情况下，用户感觉到panel的位置调整。
            pnlContainer.BackColor = Color.FromArgb(102, 102, 102);

            System.Windows.Forms.Timer winformTimer = new System.Windows.Forms.Timer();
            winformTimer.Tick += (object sender, EventArgs e) =>
            {
                winformTimer.Dispose();
                winformTimer = null;
                if (pnlContainer != null)
                {
                    pnlContainer.Controls.Clear();
                    pnlContainer.Dispose();
                    pnlContainer = null;
                }

            };
            winformTimer.Interval = displayTime;
            winformTimer.Start();
        }
    }
}
