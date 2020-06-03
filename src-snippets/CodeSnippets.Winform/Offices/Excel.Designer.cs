namespace CodeSnippets.Winform.Offices
{
    partial class Excel
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
            this.btnRead = new System.Windows.Forms.Button();
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnEasyWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(37, 18);
            this.btnRead.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(229, 77);
            this.btnRead.TabIndex = 0;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(319, 18);
            this.btnWrite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(229, 77);
            this.btnWrite.TabIndex = 1;
            this.btnWrite.Text = "Write";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnEasyWrite
            // 
            this.btnEasyWrite.Location = new System.Drawing.Point(601, 18);
            this.btnEasyWrite.Margin = new System.Windows.Forms.Padding(4);
            this.btnEasyWrite.Name = "btnEasyWrite";
            this.btnEasyWrite.Size = new System.Drawing.Size(229, 77);
            this.btnEasyWrite.TabIndex = 2;
            this.btnEasyWrite.Text = "Easy Write";
            this.btnEasyWrite.UseVisualStyleBackColor = true;
            this.btnEasyWrite.Click += new System.EventHandler(this.btnEasyWrite_Click);
            // 
            // Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 630);
            this.Controls.Add(this.btnEasyWrite);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.btnRead);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Excel";
            this.Text = "Excel";
            this.Load += new System.EventHandler(this.Excel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnEasyWrite;
    }
}