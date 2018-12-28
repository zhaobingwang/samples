namespace Sample.WinformClient.PrintSample
{
    partial class PrintPDF
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
            this.btnPrintExistPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrintExistPDF
            // 
            this.btnPrintExistPDF.Font = new System.Drawing.Font("Microsoft YaHei", 18F);
            this.btnPrintExistPDF.Location = new System.Drawing.Point(170, 332);
            this.btnPrintExistPDF.Name = "btnPrintExistPDF";
            this.btnPrintExistPDF.Size = new System.Drawing.Size(186, 59);
            this.btnPrintExistPDF.TabIndex = 0;
            this.btnPrintExistPDF.Text = "PrintExistPDF";
            this.btnPrintExistPDF.UseVisualStyleBackColor = true;
            this.btnPrintExistPDF.Click += new System.EventHandler(this.btnPrintExistPDF_Click);
            // 
            // PrintPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrintExistPDF);
            this.Name = "PrintPDF";
            this.Text = "PrintPDF";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintExistPDF;
    }
}