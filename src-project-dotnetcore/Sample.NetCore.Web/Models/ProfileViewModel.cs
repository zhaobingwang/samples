using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.NetCore.Web.Models
{
    public class ProfileViewModel
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public ProvinceViewModel Province { get; set; }
        public string FavColor { get; set; }
    }
}
