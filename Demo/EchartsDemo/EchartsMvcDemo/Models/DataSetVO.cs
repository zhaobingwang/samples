using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EchartsMvcDemo.Models
{
    /// <summary>
    /// 用 dimensions 指定了维度的顺序。
    /// 直角坐标系中，默认把第一个维度映射到 X 轴上，第二个维度映射到 Y 轴上。
    /// </summary>
    public class DataSetVO
    {
        public string[] Dimensions { get; set; }
        public List<Dictionary<string, string>> Source { get; set; }
    }
}
