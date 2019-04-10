namespace Sample.WinformClient.TaskAsynchronousProgramming
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
            this.btnAccessWebAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAccessWebAsync
            // 
            this.btnAccessWebAsync.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccessWebAsync.Location = new System.Drawing.Point(55, 53);
            this.btnAccessWebAsync.Name = "btnAccessWebAsync";
            this.btnAccessWebAsync.Size = new System.Drawing.Size(165, 50);
            this.btnAccessWebAsync.TabIndex = 0;
            this.btnAccessWebAsync.Text = "AccessWebAsync";
            this.btnAccessWebAsync.UseVisualStyleBackColor = true;
            this.btnAccessWebAsync.Click += new System.EventHandler(this.BtnAccessWebAsync_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAccessWebAsync);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccessWebAsync;
    }
}