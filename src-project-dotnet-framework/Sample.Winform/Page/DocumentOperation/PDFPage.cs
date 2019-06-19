using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Winform.Page.DocumentOperation
{
    public partial class PDFPage : Form
    {
        public PDFPage()
        {
            InitializeComponent();
        }

        private int totalPage = 0;
        private int currentPageIndex = 0;
        private void PDFPage_Load(object sender, EventArgs e)
        {
            pdfDocumentViewer1.LoadFromFile(@"files\PDF.pdf");
            pdfDocumentViewer1.ZoomMode = Spire.PdfViewer.Forms.ZoomMode.FitWidth;
            totalPage = pdfDocumentViewer1.PageCount;
            richTextBox1.Text += $"total page:{totalPage}\n";

            if (totalPage > 10)
            {
                btnPrint.Enabled = false;
                return;
            }
        }

        private void BtnSelPDF_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            btnPrint.Enabled = false;
            currentPageIndex = 0;

            var backgroundScheduler = TaskScheduler.Default;
            var uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            CancellationTokenSource cts = new CancellationTokenSource();
            CancellationToken token = cts.Token;
            Task.Factory.StartNew(delegate
            {
                System.Drawing.Printing.PrintController printController = new System.Drawing.Printing.StandardPrintController();    // 不显示系统默认的打印进度

                pdfDocumentViewer1.PrintSettings.PrintController = printController;
                pdfDocumentViewer1.PrintSettings.PrintPage += PrintSettings_PrintPage;
                pdfDocumentViewer1.PrintSettings.BeginPrint += PrintSettings_BeginPrint;
                pdfDocumentViewer1.PrintSettings.EndPrint += PrintSettings_EndPrint;
                pdfDocumentViewer1.PrintDoc();

            }, token, TaskCreationOptions.None, backgroundScheduler).
            ContinueWith(delegate
            {

                btnPrint.Enabled = true;
            }, token, TaskContinuationOptions.None, uiScheduler);
        }

        private void PrintSettings_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                richTextBox1.Text += $"\n已将全部打印命令发送至打印";
            }));
        }

        private void PrintSettings_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                richTextBox1.Text += $"\n准备开始打印...";
            }));
        }

        private void PrintSettings_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            currentPageIndex++;
            BeginInvoke(new MethodInvoker(() =>
            {
                richTextBox1.Text += $"\n准备打印第 {currentPageIndex}/ {totalPage} 页...";
            }));
        }
    }
}
