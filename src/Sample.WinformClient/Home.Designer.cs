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
            this.SuspendLayout();
            // 
            // btnWinformTimer
            // 
            this.btnWinformTimer.Location = new System.Drawing.Point(60, 106);
            this.btnWinformTimer.Name = "btnWinformTimer";
            this.btnWinformTimer.Size = new System.Drawing.Size(75, 23);
            this.btnWinformTimer.TabIndex = 0;
            this.btnWinformTimer.Text = "WinformTimer";
            this.btnWinformTimer.UseVisualStyleBackColor = true;
            this.btnWinformTimer.Click += new System.EventHandler(this.btnWinformTimer_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWinformTimer);
            this.Name = "Home";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWinformTimer;
    }
}

