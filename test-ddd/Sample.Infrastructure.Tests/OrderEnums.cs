using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Tests
{
    public enum CRUDPriority
    {
        /// <summary>
        /// 新增
        /// </summary>
        Create = 1,

        /// <summary>
        /// 更新
        /// </summary>
        Update = 2,

        /// <summary>
        /// 检索
        /// </summary>
        Retrieve = 3,

        /// <summary>
        /// 删除
        /// </summary>
        Delete = 4
    }
}
