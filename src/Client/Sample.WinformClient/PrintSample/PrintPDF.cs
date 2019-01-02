using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient.PrintSample
{
    public partial class PrintPDF : Form
    {
        string fileDir;
        public PrintPDF()
        {
            InitializeComponent();
            fileDir = $"{AppDomain.CurrentDomain.BaseDirectory}templates\\";
        }

        /// <summary>
        /// 使用FreeSpire.PDF打印PDF
        /// 免费版有 10 页的页数限制，在创建和加载 PDF 文档时要求文档不超过 10 页。将 PDF 文档转换为图片时，仅支持转换前 3 页。
        /// 专业版购买：http://e-iceblue.cn/buy/spire-pdf-net.html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrintPDF_Click(object sender, EventArgs e)
        {
            PdfDocument pdfDocument = new PdfDocument();
            var filePaths = GetPDFFilePathList();
            foreach (var filePath in filePaths)
            {
                //pdfDocument.PrintDocument.DocumentName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                pdfDocument.LoadFromFile(filePath);
                pdfDocument.PrintDocument.Print();
            }
        }

        private List<string> GetPDFFilePathList()
        {
            List<string> list = new List<string>();
            string fileName = $"";
            int ctr = 1;
            while (ctr <= 1)
            {
                list.Add($"{fileDir}PDF-P{ctr.ToString().PadLeft(2, '0')}.pdf");
                ctr++;
            }
            return list;
        }

        private void PrintPDF_Load(object sender, EventArgs e)
        {

        }

        private void btnUseAdobe_Click(object sender, EventArgs e)
        {
            SendToPrinter();
        }
        private void SendToPrinter()
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = $"{fileDir}PDF.pdf";
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                p.Kill();
        }
    }
}
