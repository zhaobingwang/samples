using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EchartsMvcDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EchartsMvcDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EChartsController : ControllerBase
    {
        [HttpGet("sampledata")]
        public IActionResult SampleData()
        {
            var vo = GetSampleDataVO();
            //var result = new
            //{
            //    dimensions = dimensions,
            //    source = source
            //};
            return Ok(vo);
        }

        [HttpGet("stacked_line_chart_data")]
        public IActionResult stackedLineChartData()
        {
            var vo = GetStackedLineChartDataVO();
            //var result = new
            //{
            //    dimensions = dimensions,
            //    source = source
            //};
            return Ok(vo);
        }

        [HttpGet("product_data")]
        public IActionResult PieData()
        {
            List<string[]> pie = new List<string[]>();
            //string[,] pie = new string[5, 7];
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    string[] cur = new string[] {
                        "产品",
                        DateTime.Now.AddYears(-5).Year.ToString(),
                        DateTime.Now.AddYears(-4).Year.ToString(),
                        DateTime.Now.AddYears(-3).Year.ToString(),
                        DateTime.Now.AddYears(-2).Year.ToString(),
                        DateTime.Now.AddYears(-1).Year.ToString(),
                        DateTime.Now.Year.ToString(),
                    };
                    pie.Add(cur);
                }
                else
                {
                    string[] cur = new string[] {
                        getProductName(i),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                        new Random().Next(1000,9999).ToString(),
                    };
                    pie.Add(cur);
                }
            }
            return Ok(new { source = pie });
        }

        public DataSetVO GetSampleDataVO()
        {
            DataSetVO vo = new DataSetVO();

            string[] dimensions = new string[] { "产品", "2018", "2019", "2020" };

            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            dict1.Add("产品", "手机");
            dict1.Add("2018", "1000.01");
            dict1.Add("2019", "2000.02");
            dict1.Add("2020", "5000.50");

            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            dict2.Add("产品", "服饰");
            dict2.Add("2018", "3000.01");
            dict2.Add("2019", "5000.02");
            dict2.Add("2020", "8000.50");

            Dictionary<string, string> dict3 = new Dictionary<string, string>();
            dict3.Add("产品", "日用");
            dict3.Add("2018", "11000.01");
            dict3.Add("2019", "12000.02");
            dict3.Add("2020", "15000.50");

            Dictionary<string, string> dict4 = new Dictionary<string, string>();
            dict4.Add("产品", "电脑");
            dict4.Add("2018", "21000.01");
            dict4.Add("2019", "22000.02");
            dict4.Add("2020", "25000.50");

            List<Dictionary<string, string>> source = new List<Dictionary<string, string>>();
            source.Add(dict1);
            source.Add(dict2);
            source.Add(dict3);
            source.Add(dict4);

            vo.Dimensions = dimensions;
            vo.Source = source;

            return vo;
        }

        public DataSetVO GetStackedLineChartDataVO()
        {
            DataSetVO vo = new DataSetVO();

            string[] dimensions = new string[] { "流量入口", "邮件营销", "联盟广告", "视频广告", "直接访问", "搜索引擎" };
            List<Dictionary<string, string>> source = new List<Dictionary<string, string>>();

            for (int i = 1; i < dimensions.Length; i++)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("流量入口", getWeekValue(i));

                dict.Add("邮件营销", new Random().Next(100, 999).ToString());
                dict.Add("联盟广告", new Random().Next(100, 999).ToString());
                dict.Add("视频广告", new Random().Next(100, 999).ToString());
                dict.Add("直接访问", new Random().Next(100, 999).ToString());
                dict.Add("搜索引擎", new Random().Next(100, 999).ToString());
                source.Add(dict);
            }


            vo.Dimensions = dimensions;
            vo.Source = source;

            return vo;
        }

        private string getWeekValue(int i)
        {
            string val = "未知";
            switch (i)
            {
                case 1:
                    val = "周一";
                    break;
                case 2:
                    val = "周二";
                    break;
                case 3:
                    val = "周三";
                    break;
                case 4:
                    val = "周四";
                    break;
                case 5:
                    val = "周五";
                    break;
                case 6:
                    val = "周六";
                    break;
                case 7:
                    val = "周日";
                    break;
                default:
                    break;
            }
            return val;
        }

        private string getProductName(int i)
        {

            switch (i)
            {
                case 1:
                    return "手机";
                case 2:
                    return "服饰";
                case 3:
                    return "日用";
                case 4:
                    return "电脑";
                default:
                    return "未知";
            }
        }
    }
}
