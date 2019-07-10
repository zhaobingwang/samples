namespace Sample.Winform.MQ
{
    partial class RabbitMQOperation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpLogs = new System.Windows.Forms.GroupBox();
            this.rtxLogs = new System.Windows.Forms.RichTextBox();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.grpLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogs
            // 
            this.grpLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogs.Controls.Add(this.rtxLogs);
            this.grpLogs.Location = new System.Drawing.Point(6, 235);
            this.grpLogs.Name = "grpLogs";
            this.grpLogs.Size = new System.Drawing.Size(782, 203);
            this.grpLogs.TabIndex = 1;
            this.grpLogs.TabStop = false;
            this.grpLogs.Text = "Logs";
            // 
            // rtxLogs
            // 
            this.rtxLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxLogs.Location = new System.Drawing.Point(3, 17);
            this.rtxLogs.Name = "rtxLogs";
            this.rtxLogs.Size = new System.Drawing.Size(776, 183);
            this.rtxLogs.TabIndex = 0;
            this.rtxLogs.Text = "";
            // 
            // pnlControl
            // 
            this.pnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControl.Location = new System.Drawing.Point(6, 12);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(782, 217);
            this.pnlControl.TabIndex = 2;
            // 
            // RabbitMQOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.grpLogs);
            this.Name = "RabbitMQOperation";
            this.Text = "RabbitMQ";
            this.Load += new System.EventHandler(this.PublishMessage_Load);
            this.grpLogs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogs;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.RichTextBox rtxLogs;
    }
}