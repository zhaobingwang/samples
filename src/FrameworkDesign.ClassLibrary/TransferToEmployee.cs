using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class TransferToEmployee
    {
    }

    /// <summary>
    /// 转账元数据
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class TransferSource : Attribute
    {
        public TransferSourceType TransferType { get; set; }
    }

    /// <summary>
    /// 转账类型
    /// </summary>
    public enum TransferSourceType
    {
        /// <summary>
        /// 发工资
        /// </summary>
        Salary = 1,

        /// <summary>
        /// 报销
        /// </summary>
        Reimburse = 2,

        /// <summary>
        /// 借款
        /// </summary>
        Loan = 3
    }
}
