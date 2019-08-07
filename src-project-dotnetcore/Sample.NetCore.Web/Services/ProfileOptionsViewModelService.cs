using Sample.NetCore.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.NetCore.Web.Services
{
    public class ProfileOptionsService
    {
        public List<string> ListGenders()
        {
            return new List<string>() { "男", "女" };
        }

        public List<ProvinceViewModel> ListProvinces()
        {
            return new List<ProvinceViewModel>() {
                new ProvinceViewModel("北京","Beijing"),
                new ProvinceViewModel("上海","Shanghai"),
                new ProvinceViewModel("浙江","Zhejiang")
            };
        }

        public List<string> ListColors()
        {
            return new List<string>() { "红", "黄", "蓝" };
        }
    }
}
