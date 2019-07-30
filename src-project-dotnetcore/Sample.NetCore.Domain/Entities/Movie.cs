using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sample.NetCore.Domain.Entities
{
    public class Movie : BaseEntity
    {
        [Display(Name = "电影名")]
        [Required(ErrorMessage = "电影名字是必填的内容")]
        public string Title { get; set; }

        // 关于System.ComponentModel.DataAnnotations Namespace
        // https://docs.microsoft.com/zh-cn/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.2
        [Display(Name = "发行日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "类型")]
        public string Genre { get; set; }

        [Display(Name = "售价")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Rating { get; set; }
    }
}
