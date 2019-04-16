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
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var logs = await _logRepository.GetPaginatedList(pageNumber, 10);
            return View(logs);
        }


        public async Task<IActionResult> Details(long id)
        {
            var log = await _logRepository.GetAsync(id);
            return View(log);
        }
    }
}