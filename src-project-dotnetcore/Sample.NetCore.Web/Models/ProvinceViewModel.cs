using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.NetCore.Web.Models
{
    public class ProvinceViewModel
    {
        public ProvinceViewModel(string name, string pinyin)
        {
            Name = name;
            Pinyin = pinyin;
        }
        public string Name { get; set; }
        public string Pinyin { get; set; }
    }
}
