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

        private Form _parent;
        private string _message;
        private Font _messageFont;
        private Bitmap _loadingBitmap;
        private Size _loadingBitmapSize;
        private Size _containerSize;

        public PleaseWait(Form parent)
        {
            _parent = parent;
            _containerSize = new Size(parent.Width, parent.Height);
            _message = "请等待...";
            _messageFont = new Font("微软雅黑", 18);
        }
        public PleaseWait(Form parent, Size containerSize) : this(parent)
        {
            _containerSize = containerSize;
        }

        public PleaseWait(Form parent, string message) : this(parent)
        {
            _message = message;
        }
        public PleaseWait(Form parent, Size containerSize, string message) : this(parent, message)
        {
            _containerSize = containerSize;
        }
        public PleaseWait(Form parent, Size containerSize, string message, Font messageFont) : this(parent, containerSize, message)
        {
            _messageFont = messageFont;
        }


        public PleaseWait(Form parent, string message, Bitmap loadingBitmap) : this(parent, message)
        {
            _loadingBitmap = loadingBitmap;
            _loadingBitmapSize = new Size(75, 75);
        }
        public PleaseWait(Form parent, string message, Font messageFont, Bitmap loadingBitmap) : this(parent, message,loadingBitmap)
        {
            _messageFont = messageFont;
        }
        public PleaseWait(Form parent, string message, Bitmap loadingBitmap, Size loadingBitmapSize) : this(parent, message, loadingBitmap)
        {
            _loadingBitmapSize = loadingBitmapSize;
        }
        public PleaseWait(Form parent, string message,Font messageFont, Bitmap loadingBitmap, Size loadingBitmapSize) : this(parent, message, loadingBitmap,loadingBitmapSize)
        {
            _messageFont = messageFont;
            _loadingBitmapSize = loadingBitmapSize;
            _containerSize = new Size(parent.Width, parent.Height);
        }

        public PleaseWait(Form parent, Size containerSize, string message, Bitmap loadingBitmap) : this(parent, containerSize, message)
        {
            _loadingBitmap = loadingBitmap;
            _loadingBitmapSize = new Size(75, 75);
        }
        public PleaseWait(Form parent, Size containerSize, string message, Bitmap loadingBitmap, Size loadingBitmapSize) : this(parent, containerSize, message, loadingBitmap)
        {
            _loadingBitmapSize = loadingBitmapSize;
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
            pnlContainer.Size = _containerSize;
            pnlContainer.BorderStyle = BorderStyle.None;
            #endregion

            #region message of label
            lblMessage = new Label();
            lblMessage.Text = _message;
            lblMessage.AutoSize = true;
            lblMessage.Width = pnlContainer.Width;
            lblMessage.MaximumSize = new Size(pnlContainer.Width, 0);
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Font = new Font("微软雅黑", 18);
            lblMessage.BackColor = Color.Transparent;
            #endregion

            #region picture of loading
            picLoading = new PictureBox();
            picLoading.Image = _loadingBitmap;
            picLoading.Size = _loadingBitmapSize;
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
