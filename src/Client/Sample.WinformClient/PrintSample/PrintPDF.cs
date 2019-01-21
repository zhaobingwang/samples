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
            PdfDocument pdfDocument;
            var filePaths = GetPDFFilePathList();
            foreach (var filePath in filePaths)
            {
                pdfDocument = new PdfDocument();
                pdfDocument.LoadFromFile(filePath);
                lblStatus.Text = $"总页数：{pdfDocument.Pages.Count}";
                PrintDocument printDoc = pdfDocument.PrintDocument;
                printDoc.PrintController = new StandardPrintController();   // dont't show the print dialog box
                printDoc.Print();

                pdfDocument.Close();
                pdfDocument.Dispose();
                printDoc.Dispose();
            }

        }

        private List<string> GetPDFFilePathList()
        {
            List<string> list = new List<string>();
            list.Add($"{fileDir}PDF.pdf");
            return list;
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

        private void PrintPDFFromURL()
        {
            System.Net.WebClient client = new System.Net.WebClient();
            List<string> urls = GetURLs();

            int index = 1;
            int total = urls.Count();
            foreach (var url in urls)
            {
                byte[] data = client.DownloadData(url);
                string path = AppDomain.CurrentDomain.BaseDirectory;
                FileStream fs = new FileStream(path + $"test-{index}.pdf", FileMode.Create);

                index++;

                //将byte数组写入文件中
                fs.Write(data, 0, data.Length);
                fs.Close();
            }


        }

        private List<string> GetURLs()
        {
            List<string> list = new List<string>();
            return list;
        }

        private void btnPrintPDFFromURL_Click(object sender, EventArgs e)
        {
            //PrintPDFFromURL();

            System.Net.WebClient client = new System.Net.WebClient();
            List<string> urls = GetURLs();

            int index = 1;
            int total = urls.Count();
            foreach (var url in urls)
            {
                // 下载PDF
                byte[] data = client.DownloadData(url);
                string path = AppDomain.CurrentDomain.BaseDirectory;
                FileStream fs = new FileStream(path + $"test-{index}.pdf", FileMode.Create);
                //将byte数组写入文件中
                fs.Write(data, 0, data.Length);
                fs.Close();

                // 打印PDF
                string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}test-{index}.pdf";
                PdfDocument pdfDocument = new PdfDocument();
                pdfDocument.LoadFromFile(filePath);
                PrintDocument printDoc = pdfDocument.PrintDocument;
                printDoc.PrintController = new StandardPrintController();   // dont't show the print dialog box
                printDoc.Print();

                pdfDocument.Close();
                pdfDocument.Dispose();
                printDoc.Dispose();

                index++;
            }
        }
    }
}
