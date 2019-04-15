using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sample.Infrastructure.Repositories;

namespace Sample.Web.Controllers
{
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;
        private LogRepository _logRepository;
        public LogController(ILogger<LogController> logger, LogRepository logRepository)
        {
            _logger = logger;
            _logRepository = logRepository;
        }
        public async Task<IActionResult> Index()
        {
            var logs = await _logRepository.GetAllAsync();
            return View(logs);
        }
    }
}