using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FrameworkDesign.ClassLibrary
{
    public class Items : List<Item>, IEnumerable<Item>
    {
        public const string VipString = "VIP_";
        public const string NormalString = "Normal_";
        public Items()
        {
            this.Add(new Item() { Code = $"{VipString}001", Name = "小米笔记本Pro", Price = 6999.00 });
            this.Add(new Item() { Code = $"{NormalString}001", Name = "Cherry MX Board 8.0 机械键盘", Price = 1779.00 });
            this.Add(new Item() { Code = $"{VipString}002", Name = "戴尔 U2417H 23.8英寸显示器", Price = 1479.00 });
            this.Add(new Item() { Code = $"{NormalString}002", Name = "金士顿DDR4 骇客神条 16G", Price = 599.00 });
        }
        public IEnumerable<Item> GetVIPItems()
        {
            if (this.Count == 0) return null;

            var result = from item in this where item.Code.StartsWith("VIP") select item;
            return result.ToList();
        }

        public IEnumerable<Item> GetNormalItems()
        {
            if (this.Count == 0) return null;

            var result = from item in this where item.Code.StartsWith("Normal") select item;
            return result.ToList();
        }
    }
}
