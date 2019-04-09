namespace Sample.WinformClient
{
    partial class Home
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
            this.btnWinformTimer = new System.Windows.Forms.Button();
            this.btnDelay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWinformTimer
            // 
            this.btnWinformTimer.Location = new System.Drawing.Point(80, 132);
            this.btnWinformTimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWinformTimer.Name = "btnWinformTimer";
            this.btnWinformTimer.Size = new System.Drawing.Size(100, 29);
            this.btnWinformTimer.TabIndex = 0;
            this.btnWinformTimer.Text = "WinformTimer";
            this.btnWinformTimer.UseVisualStyleBackColor = true;
            this.btnWinformTimer.Click += new System.EventHandler(this.btnWinformTimer_Click);
            // 
            // btnDelay
            // 
            this.btnDelay.Location = new System.Drawing.Point(357, 334);
            this.btnDelay.Name = "btnDelay";
            this.btnDelay.Size = new System.Drawing.Size(128, 60);
            this.btnDelay.TabIndex = 1;
            this.btnDelay.Text = "Delay";
            this.btnDelay.UseVisualStyleBackColor = true;
            this.btnDelay.Click += new System.EventHandler(this.BtnDelay_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.btnDelay);
            this.Controls.Add(this.btnWinformTimer);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Home";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWinformTimer;
        private System.Windows.Forms.Button btnDelay;
    }
}

