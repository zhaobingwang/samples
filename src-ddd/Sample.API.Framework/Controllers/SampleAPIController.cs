using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Sample.API.Framework.Controllers
{
    [RoutePrefix("api/samples")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SampleAPIController : ApiController
    {
        List<SampleProduct> products = null;
        public SampleAPIController()
        {
            products = new List<SampleProduct>();
            for (int i = 1; i <= 100; i++)
            {
                products.Add(new SampleProduct()
                {
                    Id = i,
                    Name = $"产品{i}"
                });
            }
        }
        [HttpGet]
        [Route("")]
        [Route("get-date-time")]
        public string GetDateTime()
        {
            return DateTimeOffset.Now.ToString();
        }

        [HttpGet]
        [Route("get-string")]
        public string GetString()
        {
            return "hello,world";
        }

        [HttpGet]
        [Route("get-all-products")]
        public IEnumerable<SampleProduct> GetProducts()
        {
            return products;
        }

        /// <summary>
        /// 获取某个产品
        /// </summary>
        /// <param name="id">产品ID</param>
        /// <returns>产品的json信息</returns>
        [HttpGet]
        [Route("get-product/{id:int}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        [Route("post-file")]
        public IHttpActionResult PostFile([FromBody] string name)
        {
            return Ok(name);
        }
    }

    public class Account
    {
        public string accountNumber { get; set; }
    }

    public class SampleUploadImage
    {
        public string key { get; set; }
        public byte[] value { get; set; }
    }

    public class SampleProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
