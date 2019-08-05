using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.NetCore.Web
{
    public class SlugifyApiRouteAttribute : Attribute, IRouteTemplateProvider
    {
        public string Template => "api/[controller]/[action]";
        public int? Order { get; set; }
        public string Name { get; set; }
    }
}
