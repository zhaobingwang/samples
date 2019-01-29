using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient.PDFHandler
{
    public partial class SpirePDFViewer : Form
    {
        private int index = 0;
        private int total = 0;
        private string filePath = "";
        private string baseDir = "";
        List<string> pdfs;
        public SpirePDFViewer()
        {
            InitializeComponent();
            baseDir = $"{AppDomain.CurrentDomain.BaseDirectory}temp\\";
            pdfs = new List<string>();
        }

        private void SpirePDFViewer_Load(object sender, EventArgs e)
        {
            Next.Enabled = false;
            Prev.Enabled = false;
        }
        private void LoadPDF_Click(object sender, EventArgs e)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            List<string> urls = GetURLs();

            filePath = $"{baseDir}CurrentUser\\";
            Directory.CreateDirectory(filePath);


            total = urls.Count();
            foreach (var url in urls)
            {
                // 下载PDF
                byte[] data = client.DownloadData(url);
                FileStream fs = new FileStream($"{filePath}test-{index}.pdf", FileMode.Create);
                fs.Write(data, 0, data.Length);
                fs.Close();

                pdfs.Add($"{filePath}test-{index}.pdf");
                index++;
            }
            index = 0;
            if (pdfs.Count > 1)
                Next.Enabled = true;
            if (pdfs.Count > 0)
                pdfDocumentViewer1.LoadFromFile(pdfs[index]);
        }


        private void Next_Click(object sender, EventArgs e)
        {
            index++;
            if (pdfs.Count == 0 || (pdfs.Count > 0 && index + 1 > pdfs.Count))
            {
                index = pdfs.Count - 1;
                lblMessage.Text = "no data";
                return;
            }
            Prev.Enabled = true;
            pdfDocumentViewer1.LoadFromFile(pdfs[index]);
            index++;
        }

        private void Prev_Click(object sender, EventArgs e)
        {
            index--;
            if (pdfs.Count == 0 || index < 0 || index + 1 > pdfs.Count)
            {
                index = 0;
                lblMessage.Text = "no data";
                return;
            }
            Next.Enabled = true;
            pdfDocumentViewer1.LoadFromFile(pdfs[index]);
        }

        private List<string> GetURLs()
        {
            List<string> list = new List<string>();
            list.Add("http://www.takaramono-pj.jp/wp-content/uploads/2018/09/samplePDF.pdf");   // 1 page
            list.Add("https://www.adobe.com/support/products/enterprise/knowledgecenter/media/c4611_sample_explain.pdf");   //4 page
            return list;
        }

        private void PrintPDF_Click(object sender, EventArgs e)
        {
            foreach (var pdf in pdfs)
            {
                pdfDocumentViewer1.LoadFromFile(pdf);
                pdfDocumentViewer1.PrintDoc();
            }
        }

        private void SpirePDFViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 删除下载的临时pdf文件
            if (Directory.Exists(filePath))
                DeleteDirectory(filePath);
        }
        void DeleteDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                DirectoryInfo[] childs = dir.GetDirectories();
                foreach (DirectoryInfo child in childs)
                {
                    child.Delete(true);
                }
                dir.Delete(true);
            }
        }
    }
}
