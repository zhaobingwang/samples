using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlLib
{
    public partial class UserInfoHead : UserControl
    {
        public UserInfoHead()
        {
            InitializeComponent();
        }

        [Description("姓名"), Category("个人信息")]
        public string UserName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        [Description("性别"), Category("个人信息")]
        public string Sex
        {
            get { return lblSex.Text; }
            set { lblSex.Text = value; }
        }

        [Description("手机号"), Category("个人信息")]
        public string CellPhoneNumber
        {
            get { return lblCellPhoneNumber.Text; }
            set { lblCellPhoneNumber.Text = value; }
        }

        [Description("现住址"), Category("个人信息")]
        public string Address
        {
            get { return lblAddress.Text; }
            set { lblAddress.Text = value; }
        }
    }
}
