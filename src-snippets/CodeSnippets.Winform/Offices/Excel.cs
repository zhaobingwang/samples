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

namespace CodeSnippets.Winform.Offices
{
    public partial class Excel : Form
    {
        public Excel()
        {
            InitializeComponent();
        }

        private void Excel_Load(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Offices\\sample.xlsx", FileMode.Open, FileAccess.Read);
            var temp = ExcelHelper.GetList<User>(fs, 1);
            var aa = 1;
        }
    }
    class User
    {
        [Column(0)]
        public string ID { get; set; }

        [Column(1)]
        public string Name { get; set; }

        [Column(2)]
        public string DOB { get; set; }

        [Column(3)]
        public string Gender { get; set; }

        [Column(4)]
        public string Status { get; set; }
    }
}
