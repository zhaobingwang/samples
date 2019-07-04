using Sample.Domain.Framework.ClickHouse.Entities;
using Sample.Infrastructure.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample.Winform.CK
{
    public partial class CKIndexForm : Form
    {
        public CKIndexForm()
        {
            InitializeComponent();
        }
        BaseAccess<Test> baseAccess = new BaseAccess<Test>();
        private void Button1_Click(object sender, EventArgs e)
        {
            Test t = new Test()
            {
                I32Value = 1,
                I64Value = 1,
                StringValue = "测试",
                DateValue = DateTime.Now,
                DateTimeValue = DateTime.Now.ToUniversalTime(),
                Float64Value = 1.1,
                PartitionByValue = new DateTime(2000, 1, 1),
                PKI64 = 1,
                PKString = "分类1",

            };
            try
            {
                var result = baseAccess.Insert(t, "test");
                rtbLogs.Text += $"{result}\n";
            }
            catch (Exception ex)
            {
                rtbLogs.Text += $"{ex}\n";
            }
        }
    }
}
