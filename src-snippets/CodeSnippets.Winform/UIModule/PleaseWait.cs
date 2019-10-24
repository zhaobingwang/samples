using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeSnippets.Winform.UIModule
{
    public class PleaseWait
    {
        /// <summary>
        /// 等待消息的容器
        /// </summary>
        public static Panel pnl;

        /// <summary>
        /// 等待消息的文本信息
        /// </summary>
        private Label lblMessage;

        /// <summary>
        /// 等待消息需要显示的父窗体
        /// </summary>
        private Panel parent;

        private PictureBox picLoading;

        /// <summary>
        /// 等待消息正文内容
        /// </summary>
        private string _message;

        private Image LoadingImage;

        /// <summary>
        /// 要显示的消息
        /// </summary>
        /// <param name="message"></param>
        public PleaseWait(Panel parent, Image loading, string message)
        {
            _message = message;
            this.parent = parent;
            LoadingImage = loading;
        }

        /// <summary>
        /// 显示等待panel
        /// </summary>
        public void Show()
        {
            CreateMessage();
        }

        /// <summary>
        /// 刷新消息
        /// </summary>
        /// <param name="message"></param>
        public void Refresh(string message)
        {
            if (lblMessage != null)
                lblMessage.Text = message;
            else
                throw new Exception($"{nameof(lblMessage)} is undefined");
        }

        /// <summary>
        /// 删除等待panel
        /// </summary>
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
            if (pnl != null)
            {
                pnl.Controls.Clear();
                pnl.Dispose();
                pnl = null;
            }
        }

        /// <summary>
        /// 创建等待消息窗体
        /// </summary>
        private void CreateMessage()
        {
            #region message container
            pnl = new Panel();
            pnl.Width = parent.Width;
            pnl.Height = parent.Height;
            pnl.BorderStyle = BorderStyle.None;
            #endregion

            #region message of lable
            lblMessage = new Label();
            lblMessage.Text = _message;
            lblMessage.AutoSize = true;
            lblMessage.Width = parent.Width - 100;
            lblMessage.MaximumSize = new Size(parent.Width - 100, 0);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Font = new Font("微软雅黑", 18);
            lblMessage.BackColor = Color.Transparent;
            #endregion

            #region picture of loading
            picLoading = new PictureBox();
            picLoading.Size = new Size(37, 37);
            picLoading.Image = LoadingImage;
            #endregion

            // 添加控件
            pnl.Controls.Add(lblMessage);   // 向容器中添加消息
            pnl.Controls.Add(picLoading);   // 向容器中添加加载动画
            parent.Controls.Add(pnl);   // 向窗体中添加容器

            // 设置容器位置（在父窗体中添加完成后设置才有效）
            pnl.Left = 0;
            pnl.Top = 0;
            pnl.BringToFront();

            // 设置文本消息位置（在父窗体中添加完成后设置才有效）
            lblMessage.Top = (pnl.Height - lblMessage.Height) / 2;
            lblMessage.Left = (pnl.Width - lblMessage.Width) / 2;


            // 设置加载动画位置（在父窗体中添加完成后设置才有效）
            picLoading.Left = (pnl.Width - picLoading.Width) / 2;
            picLoading.Top = lblMessage.Top - picLoading.Height - 30;
        }
    }
}
