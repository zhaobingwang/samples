using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.API.Framework.DTOs
{
    /// <summary>
    /// 数据细节信息数据传输对象
    /// </summary>
    public class BookDetailDto
    {
        /// <summary>
        /// 书名
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 流派
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// 出版时间
        /// </summary>
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }
    }
}