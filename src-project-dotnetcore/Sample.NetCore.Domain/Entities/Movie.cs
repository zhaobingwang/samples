using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sample.NetCore.Domain.Entities
{
    // 关于System.ComponentModel.DataAnnotations Namespace
    // https://docs.microsoft.com/zh-cn/dotnet/api/system.componentmodel.dataannotations?view=netcore-2.2
    public class Movie : BaseEntity
    {
        [Display(Name = "电影名")]
        [Required(ErrorMessage = "电影名字是必填的内容")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "电影名字长度范围在3~60")]
        public string Title { get; set; }

        [Display(Name = "发行日期")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "类型")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        public string Genre { get; set; }

        [Display(Name = "售价")]
        [Range(1, 100, ErrorMessage = "售价范围在1~100")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "级别")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }
    }
}
