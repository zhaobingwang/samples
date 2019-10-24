namespace CodeSnippets.Winform
{
    partial class Home
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlLoading
            // 
            this.pnlLoading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoading.Location = new System.Drawing.Point(62, 68);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(552, 307);
            this.pnlLoading.TabIndex = 0;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlLoading);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLoading;
    }
}

