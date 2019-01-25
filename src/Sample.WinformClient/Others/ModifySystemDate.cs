using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.WinformClient.Others
{
    public partial class ModifySystemDate : Form
    {
        public ModifySystemDate()
        {
            InitializeComponent();
        }


        private void btnModifyDate_Click(object sender, EventArgs e)
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = 2009; // must be short
            st.wMonth = 1;
            st.wDay = 1;
            st.wHour = 0;
            st.wMinute = 0;
            st.wSecond = 0;

            // 需要以管理员身份运行程序才可以生效
            SetSystemTime(ref st); // invoke this method.
            lblDate.Text = DateTime.Now.ToString();
        }

        private void ModifySystemDate_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;
    }
}
