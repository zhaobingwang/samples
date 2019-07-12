using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.NetCore.Domain.Entities
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; }

        // 关于System.ComponentModel.DataAnnotations Namespace
        // https://docs.microsoft.com/zh-cn/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.2
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
