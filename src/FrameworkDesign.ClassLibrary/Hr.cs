using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class Hr
    {
        public void ToSalary(Employee employee)
        {
            var transferSource = typeof(Employee).GetMethod("TransferToEmployee").GetParameters()[0].GetCustomAttributes(false)[0] as TransferSource;
            switch (transferSource.TransferType)
            {
                case TransferSourceType.Salary:
                    employee.TransferToEmployee(20000);
                    break;
                case TransferSourceType.Reimburse:
                    employee.TransferToEmployee(1000);
                    break;
                case TransferSourceType.Loan:
                    employee.TransferToEmployee(100000);
                    break;
                default:
                    break;
            }
        }
    }
}
