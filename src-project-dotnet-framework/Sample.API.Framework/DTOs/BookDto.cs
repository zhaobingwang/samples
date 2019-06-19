using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.API.Framework.DTOs
{
    /// <summary>
    /// 数据主要信息数据传输对象
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string author { get; set; }

        /// <summary>
        /// 流派
        /// </summary>
        public string genre { get; set; }
    }
}