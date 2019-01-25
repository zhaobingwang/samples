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
            this.btnPrintPDF = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnUseAdobe = new System.Windows.Forms.Button();
            this.btnPrintPDFFromURL = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrintPDF
            // 
            this.btnPrintPDF.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btnPrintPDF.Location = new System.Drawing.Point(313, 329);
            this.btnPrintPDF.Name = "btnPrintPDF";
            this.btnPrintPDF.Size = new System.Drawing.Size(186, 59);
            this.btnPrintPDF.TabIndex = 0;
            this.btnPrintPDF.Text = "PrintPDF";
            this.btnPrintPDF.UseVisualStyleBackColor = true;
            this.btnPrintPDF.Click += new System.EventHandler(this.btnPrintPDF_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(345, 194);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 12);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status";
            // 
            // btnUseAdobe
            // 
            this.btnUseAdobe.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btnUseAdobe.Location = new System.Drawing.Point(505, 329);
            this.btnUseAdobe.Name = "btnUseAdobe";
            this.btnUseAdobe.Size = new System.Drawing.Size(186, 59);
            this.btnUseAdobe.TabIndex = 3;
            this.btnUseAdobe.Text = "UseAdobe";
            this.btnUseAdobe.UseVisualStyleBackColor = true;
            this.btnUseAdobe.Click += new System.EventHandler(this.btnUseAdobe_Click);
            // 
            // btnPrintPDFFromURL
            // 
            this.btnPrintPDFFromURL.Font = new System.Drawing.Font("微软雅黑", 18F);
            this.btnPrintPDFFromURL.Location = new System.Drawing.Point(47, 329);
            this.btnPrintPDFFromURL.Name = "btnPrintPDFFromURL";
            this.btnPrintPDFFromURL.Size = new System.Drawing.Size(260, 59);
            this.btnPrintPDFFromURL.TabIndex = 4;
            this.btnPrintPDFFromURL.Text = "PrintPDFFromURL";
            this.btnPrintPDFFromURL.UseVisualStyleBackColor = true;
            this.btnPrintPDFFromURL.Click += new System.EventHandler(this.btnPrintPDFFromURL_Click);
            // 
            // PrintPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrintPDFFromURL);
            this.Controls.Add(this.btnUseAdobe);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnPrintPDF);
            this.Name = "PrintPDF";
            this.Text = "PrintPDF";
            this.Load += new System.EventHandler(this.PrintPDF_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintPDF;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnUseAdobe;
        private System.Windows.Forms.Button btnPrintPDFFromURL;
    }
}