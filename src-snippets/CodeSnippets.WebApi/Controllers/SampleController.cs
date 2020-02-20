using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeSnippets.Infrastructure.Data;
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
        public SampleController(SqliteDbContext sqliteDbContext, ILogger<SampleController> logger)
        {
            _sqliteDbContext = sqliteDbContext;
            _logger = logger;
        }

        public async Task<IActionResult> Get(int id)
        {
            var sampleData = await _sqliteDbContext.SampleEntity
                .SingleOrDefaultAsync(s => s.Id == id);
            return Ok(sampleData);
        }
    }
}