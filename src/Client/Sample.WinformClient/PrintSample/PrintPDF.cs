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
        public PrintPDF()
        {
            InitializeComponent();
        }
        
        private void btnPrintExistPDF_Click(object sender, EventArgs e)
        {
            string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}templates\\DemoPDF02.pdf";
            PdfDocument pdf = new PdfDocument(filePath);
            pdf.Print();
        }
    }
}
