namespace Sample.WinformClient.PDFHandler
{
    partial class SpirePDFViewer
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
            this.pdfDocumentViewer1 = new Spire.PdfViewer.Forms.PdfDocumentViewer();
            this.LoadPDF = new System.Windows.Forms.Button();
            this.Prev = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.PrintPDF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pdfDocumentViewer1
            // 
            this.pdfDocumentViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.pdfDocumentViewer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pdfDocumentViewer1.Location = new System.Drawing.Point(0, 0);
            this.pdfDocumentViewer1.MultiPagesThreshold = 60;
            this.pdfDocumentViewer1.Name = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.Size = new System.Drawing.Size(939, 468);
            this.pdfDocumentViewer1.TabIndex = 0;
            this.pdfDocumentViewer1.Text = "pdfDocumentViewer1";
            this.pdfDocumentViewer1.Threshold = 60;
            this.pdfDocumentViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.Default;
            // 
            // LoadPDF
            // 
            this.LoadPDF.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.LoadPDF.Location = new System.Drawing.Point(334, 511);
            this.LoadPDF.Name = "LoadPDF";
            this.LoadPDF.Size = new System.Drawing.Size(148, 48);
            this.LoadPDF.TabIndex = 1;
            this.LoadPDF.Text = "LoadPDF";
            this.LoadPDF.UseVisualStyleBackColor = true;
            this.LoadPDF.Click += new System.EventHandler(this.LoadPDF_Click);
            // 
            // Prev
            // 
            this.Prev.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Prev.Location = new System.Drawing.Point(169, 511);
            this.Prev.Name = "Prev";
            this.Prev.Size = new System.Drawing.Size(148, 48);
            this.Prev.TabIndex = 2;
            this.Prev.Text = "Prev";
            this.Prev.UseVisualStyleBackColor = true;
            this.Prev.Click += new System.EventHandler(this.Prev_Click);
            // 
            // Next
            // 
            this.Next.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Next.Location = new System.Drawing.Point(712, 511);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(148, 48);
            this.Next.TabIndex = 3;
            this.Next.Text = "Next";
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(435, 471);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(47, 12);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message";
            // 
            // PrintPDF
            // 
            this.PrintPDF.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.PrintPDF.Location = new System.Drawing.Point(522, 511);
            this.PrintPDF.Name = "PrintPDF";
            this.PrintPDF.Size = new System.Drawing.Size(148, 48);
            this.PrintPDF.TabIndex = 5;
            this.PrintPDF.Text = "PrintPDF";
            this.PrintPDF.UseVisualStyleBackColor = true;
            this.PrintPDF.Click += new System.EventHandler(this.PrintPDF_Click);
            // 
            // SpirePDFViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 597);
            this.Controls.Add(this.PrintPDF);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Prev);
            this.Controls.Add(this.LoadPDF);
            this.Controls.Add(this.pdfDocumentViewer1);
            this.Name = "SpirePDFViewer";
            this.Text = "SpirePDFViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpirePDFViewer_FormClosing);
            this.Load += new System.EventHandler(this.SpirePDFViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Spire.PdfViewer.Forms.PdfDocumentViewer pdfDocumentViewer1;
        private System.Windows.Forms.Button LoadPDF;
        private System.Windows.Forms.Button Prev;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button PrintPDF;
    }
}