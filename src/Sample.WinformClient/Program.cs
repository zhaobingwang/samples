using System;
using System.Windows.Forms;
using Sample.WinformClient.DesignPatterns;
using Sample.WinformClient.JobScheduling;
using Sample.WinformClient.Others;
using Sample.WinformClient.PDFHandler;
using Sample.WinformClient.PrintSample;
using Sample.WinformClient.Tests;

namespace Sample.WinformClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TaskAsynchronousProgramming.Home());
        }
    }
}
