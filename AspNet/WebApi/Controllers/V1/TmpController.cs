using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WebApi.Controllers.V1
{
    [Route("api/v1/rbac/[controller]")]
    [ApiController]
    public class TmpController : ControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _provider;
        public TmpController(IActionDescriptorCollectionProvider provider)
        {
            _provider = provider;
        }

        [Tmp(ActionCode = "add")]
        [HttpGet("all")]
        public ActionResult AllAction()
        {
            //Assembly asm = Assembly.GetExecutingAssembly();

            //var actions = asm.GetTypes()
            //     .Where(type => typeof(ControllerBase).IsAssignableFrom(type)) //filter controllers
            //     .SelectMany(type => type.GetMethods())
            //     .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)));
            var routes = _provider.ActionDescriptors.Items.Select(x => new
            {
                Action = x.RouteValues["Action"],
                Controller = x.RouteValues["Controller"],
                Name = x.AttributeRouteInfo.Name,
                Template = x.AttributeRouteInfo.Template,
                ActionCode = ((ControllerActionDescriptor)x).MethodInfo.GetCustomAttribute<TmpAttribute>()?.ActionCode
            }).ToList();
            return Ok(routes);
        }
    }
}
