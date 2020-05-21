namespace CodeSnippets.Winform
{
    partial class Tmp
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
            this.btnThrowException = new System.Windows.Forms.Button();
            this.btnThrowTaskException = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnThrowException
            // 
            this.btnThrowException.Location = new System.Drawing.Point(12, 12);
            this.btnThrowException.Name = "btnThrowException";
            this.btnThrowException.Size = new System.Drawing.Size(121, 67);
            this.btnThrowException.TabIndex = 0;
            this.btnThrowException.Text = "ThrowException";
            this.btnThrowException.UseVisualStyleBackColor = true;
            this.btnThrowException.Click += new System.EventHandler(this.btnThrowException_Click);
            // 
            // btnThrowTaskException
            // 
            this.btnThrowTaskException.Location = new System.Drawing.Point(174, 12);
            this.btnThrowTaskException.Name = "btnThrowTaskException";
            this.btnThrowTaskException.Size = new System.Drawing.Size(121, 67);
            this.btnThrowTaskException.TabIndex = 1;
            this.btnThrowTaskException.Text = "ThrowTaskException";
            this.btnThrowTaskException.UseVisualStyleBackColor = true;
            this.btnThrowTaskException.Click += new System.EventHandler(this.btnThrowTaskException_Click);
            // 
            // Tmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnThrowTaskException);
            this.Controls.Add(this.btnThrowException);
            this.Name = "Tmp";
            this.Text = "Tmp";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThrowException;
        private System.Windows.Forms.Button btnThrowTaskException;
    }
}