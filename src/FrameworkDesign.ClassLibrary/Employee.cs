using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public partial class Employee
    {
        partial void GetJob()
        {
            Console.WriteLine("Partial method.");
        }

        public void TransferToEmployee([TransferSource(TransferType = TransferSourceType.Salary)]int toNumber)
        {
            // 直接汇入员工银行卡
        }
    }
}
