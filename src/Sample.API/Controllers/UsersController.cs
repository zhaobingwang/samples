using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Business.Dapper;
using Sample.Data.Entities;

namespace Sample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                UserBusiness userBusiness = new UserBusiness();
                var users = userBusiness.GetAll();
                int a = 0;
                int b = 10 / a;
                return Ok(users);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }
    }
}