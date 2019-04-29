using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Infrastructure.RepositoriesDapper.MySql;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class T01Controller : ControllerBase
    {
        T01Repository _t01Repository;
        ILogger<T01Controller> _logger;
        public T01Controller(ILogger<T01Controller> logger,T01Repository t01Repository)
        {
            _logger = logger;
            _t01Repository = t01Repository;
        }

        [Route("get-all")]
        public IActionResult Get()
        {
            var result = _t01Repository.GetAll();
            return new JsonResult(result);
        }

        [HttpPost]
        [Route("insert")]
        public IActionResult Insert()
        {
            _logger.LogInformation($"excute {nameof(Insert)}");
            var result = _t01Repository.Insert(new Domain.Entities.T01
            {
                StringValue = "1",
                IntValue = 2,
                DateTimeValue = DateTime.Now,
                BooleanValue = true
            });
            return new JsonResult(result);
        }
    }
}