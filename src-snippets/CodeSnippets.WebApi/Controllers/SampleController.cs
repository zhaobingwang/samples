using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSnippets.Infrastructure.Data;
using CodeSnippets.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CodeSnippets.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly SqliteDbContext _sqliteDbContext;
        private readonly ILogger<SampleController> _logger;
        private readonly IFoo _foo;
        //public SampleController(SqliteDbContext sqliteDbContext)
        //{
        //    _sqliteDbContext = sqliteDbContext;
        //}
        //public SampleController(SqliteDbContext sqliteDbContext, ILogger<SampleController> logger) : this(sqliteDbContext)
        //{
        //    _logger = logger;
        //}

        public SampleController(SqliteDbContext sqliteDbContext, ILogger<SampleController> logger, IFoo foo) //: this(sqliteDbContext, logger)
        {
            _logger = logger;
            _foo = foo;
            _sqliteDbContext = sqliteDbContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sampleData = await _sqliteDbContext.SampleEntity
                .SingleOrDefaultAsync(s => s.Id == id);

            if (sampleData?.StringValue == "ping")
            {
                var pingOk = _foo.Ping("localhost");
                if (!pingOk)
                    return NotFound();
            }

            return Ok(sampleData);
        }
    }
}