using Sample.API.Framework.AutoMapperConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sample.API.Framework
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            #region mapper
            //var config = new AutoMapper.MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<Book2BookDtoProfile>();
            //});
            //var mapper = config.CreateMapper();

            //AutoMapper.Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfile<Book2BookDtoProfile>();
            //});

            var cfg = new AutoMapper.Configuration.MapperConfigurationExpression();
            cfg.AddProfile<Book2BookDtoProfile>();
            AutoMapper.Mapper.Initialize(cfg);
            #endregion
        }
    }
}
