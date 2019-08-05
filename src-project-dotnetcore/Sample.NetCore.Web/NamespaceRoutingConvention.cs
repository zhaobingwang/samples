using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.NetCore.Web
{
    /// <summary>
    /// 使用应用程序模型自定义属性路由：
    /// 应用程序模型是一个在启动时创建的对象模型，MVC 可使用其中的所有元数据来路由和执行操作。 
    /// 应用程序模型包含从路由属性收集（通过 IRouteTemplateProvider）的所有数据。
    /// 可通过编写约定在启动时修改应用程序模型，以便自定义路由的行为方式。 
    /// 此部分通过一个简单的示例说明了如何使用应用程序模型自定义路由。
    /// 见：https://docs.microsoft.com/zh-cn/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.2#using-application-model-to-customize-attribute-routes
    /// </summary>
    //public class NamespaceRoutingConvention
    //{
    //    private readonly string _baseNamespace;

    //    public NamespaceRoutingConvention(string baseNamespace)
    //    {
    //        _baseNamespace = baseNamespace;
    //    }

    //    public void Apply(ControllerModel controller)
    //    {
    //        var hasRouteAttributes = controller.Selectors.Any(selector =>
    //                                                selector.AttributeRouteModel != null);
    //        if (hasRouteAttributes)
    //        {
    //            // This controller manually defined some routes, so treat this 
    //            // as an override and not apply the convention here.
    //            return;
    //        }

    //        // Use the namespace and controller name to infer a route for the controller.
    //        //
    //        // Example:
    //        //
    //        //  controller.ControllerTypeInfo ->    "My.Application.Admin.UsersController"
    //        //  baseNamespace ->                    "My.Application"
    //        //
    //        //  template =>                         "Admin/[controller]"
    //        //
    //        // This makes your routes roughly line up with the folder structure of your project.
    //        //
    //        var namespc = controller.ControllerType.Namespace;
    //        if (namespc == null)
    //            return;
    //        var template = new StringBuilder();
    //        template.Append(namespc, _baseNamespace.Length + 1,
    //                        namespc.Length - _baseNamespace.Length - 1);
    //        template.Replace('.', '/');
    //        template.Append("/[controller]");

    //        foreach (var selector in controller.Selectors)
    //        {
    //            selector.AttributeRouteModel = new AttributeRouteModel()
    //            {
    //                Template = template.ToString()
    //            };
    //        }
    //    }
    //}
}
