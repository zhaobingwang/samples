using HZH_Controls.Controls;
using HZH_Controls.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeSnippets.Winform.HZHControlsSnippets
{
    public partial class HZHHome : HZHBase
    {
        public HZHHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 模态框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModal_BtnClick(object sender, EventArgs e)
        {
            if (FrmDialog.ShowDialog(this, "是否删除？", "删除", true) == DialogResult.OK)
            {
                FrmDialog.ShowDialog(this, "已删除", "操作提示");
            }
            else
            {
                FrmDialog.ShowDialog(this, "未删除", "操作提示");
            }
        }

        /// <summary>
        /// 表单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnForm_BtnClick(object sender, EventArgs e)
        {
            FrmInputs frm = new FrmInputs("动态多输入窗体测试",
                           new string[] { "姓名", "电话", "身份证号", "住址" },
                           new Dictionary<string, HZH_Controls.TextInputType>() { { "电话", HZH_Controls.TextInputType.Regex }, { "身份证号", HZH_Controls.TextInputType.Regex } },
                           new Dictionary<string, string>() { { "电话", @"" }, { "身份证号", "" } },
                           new Dictionary<string, KeyBoardType>() { { "电话", KeyBoardType.UCKeyBorderNum }, { "身份证号", KeyBoardType.UCKeyBorderNum } });
            frm.ShowDialog(this);
        }

        private void btnChild_BtnClick(object sender, EventArgs e)
        {
            FrmBack frmChild = new FrmBack();
            frmChild.FrmTitle = "子窗体";
            frmChild.FormClosing += (senderChild, eChild) =>
            {
                ShowTime();
            };
            frmChild.ShowDialog(this);
        }

        public void ShowTime()
        {
            FrmDialog.ShowDialog(this, "展示时间", $"现在是{DateTime.Now}");
        }

        private void btnTxtBox_BtnClick(object sender, EventArgs e)
        {
            HZHTxtBox txtBox = new HZHTxtBox();
            txtBox.ShowDialog(this);
        }

        private void btnCalendar_BtnClick(object sender, EventArgs e)
        {
            HZHCalendar txtBox = new HZHCalendar();
            txtBox.ShowDialog(this);
        }
    }
}
