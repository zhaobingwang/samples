namespace Sample.WinformClient.DesignPatterns
{
    partial class ObserverSample
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
            this.ProcessLogs = new System.Windows.Forms.RichTextBox();
            this.SmartWatchClock = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProcessLogs
            // 
            this.ProcessLogs.Location = new System.Drawing.Point(12, 63);
            this.ProcessLogs.Name = "ProcessLogs";
            this.ProcessLogs.Size = new System.Drawing.Size(776, 374);
            this.ProcessLogs.TabIndex = 0;
            this.ProcessLogs.Text = "";
            // 
            // SmartWatchClock
            // 
            this.SmartWatchClock.AutoSize = true;
            this.SmartWatchClock.Font = new System.Drawing.Font("Microsoft YaHei", 12F);
            this.SmartWatchClock.Location = new System.Drawing.Point(13, 28);
            this.SmartWatchClock.Name = "SmartWatchClock";
            this.SmartWatchClock.Size = new System.Drawing.Size(163, 21);
            this.SmartWatchClock.TabIndex = 1;
            this.SmartWatchClock.Text = "1970-01-01 00:00:00";
            // 
            // ObserverSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SmartWatchClock);
            this.Controls.Add(this.ProcessLogs);
            this.Name = "ObserverSample";
            this.Text = "ObserverSample";
            this.Load += new System.EventHandler(this.ObserverSample_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox ProcessLogs;
        private System.Windows.Forms.Label SmartWatchClock;
    }
}