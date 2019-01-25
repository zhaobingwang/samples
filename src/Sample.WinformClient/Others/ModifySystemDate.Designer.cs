namespace Sample.WinformClient.Others
{
    partial class ModifySystemDate
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
            this.btnModifyDate = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnModifyDate
            // 
            this.btnModifyDate.Location = new System.Drawing.Point(93, 149);
            this.btnModifyDate.Name = "btnModifyDate";
            this.btnModifyDate.Size = new System.Drawing.Size(102, 60);
            this.btnModifyDate.TabIndex = 0;
            this.btnModifyDate.Text = "修改系统时间";
            this.btnModifyDate.UseVisualStyleBackColor = true;
            this.btnModifyDate.Click += new System.EventHandler(this.btnModifyDate_Click);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(240, 173);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 12);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "时间";
            // 
            // ModifySystemDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.btnModifyDate);
            this.Name = "ModifySystemDate";
            this.Text = "ModifySystemDate";
            this.Load += new System.EventHandler(this.ModifySystemDate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModifyDate;
        private System.Windows.Forms.Label lblDate;
    }
}