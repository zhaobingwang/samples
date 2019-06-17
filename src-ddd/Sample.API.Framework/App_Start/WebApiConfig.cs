using Sample.API.Framework.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Sample.API.Framework
{
    /// <summary>
    /// 配置 ASP.NET Web API 2：
    /// https://docs.microsoft.com/zh-cn/aspnet/web-api/overview/advanced/configuring-aspnet-web-api
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 注册支持浏览器的跨域访问
            config.EnableCors();

            // 自定义路由约束
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("nonzero", typeof(NonZeroConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);
        }
    }
}
