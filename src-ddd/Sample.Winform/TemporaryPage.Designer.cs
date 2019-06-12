namespace Sample.Winform
{
    partial class TemporaryPage
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSoftKeyBoard = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "btnInput";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnText
            // 
            this.btnText.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnText.Location = new System.Drawing.Point(203, 33);
            this.btnText.Name = "btnText";
            this.btnText.Size = new System.Drawing.Size(355, 73);
            this.btnText.TabIndex = 1;
            this.btnText.UseVisualStyleBackColor = true;
            this.btnText.TextChanged += new System.EventHandler(this.BtnText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // pnlSoftKeyBoard
            // 
            this.pnlSoftKeyBoard.Location = new System.Drawing.Point(400, 179);
            this.pnlSoftKeyBoard.Name = "pnlSoftKeyBoard";
            this.pnlSoftKeyBoard.Size = new System.Drawing.Size(476, 385);
            this.pnlSoftKeyBoard.TabIndex = 3;
            // 
            // TemporaryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 576);
            this.Controls.Add(this.pnlSoftKeyBoard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnText);
            this.Controls.Add(this.button1);
            this.Name = "TemporaryPage";
            this.Text = "TemporaryPage";
            this.Load += new System.EventHandler(this.TemporaryPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlSoftKeyBoard;
    }
}