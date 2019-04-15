using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using Sample.Infrastructure.Share;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Sample.Infrastructure.Repositories
{
    public class LogRepository
    {
        private readonly SampleContext _context;
        public LogRepository(SampleContext context)
        {
            _context = context ?? throw new ArgumentNullException($"{nameof(context)}");
        }

        public async Task<List<Log>> GetAllAsync()
        {
            return await _context.Logs.ToListAsync();
        }

        public async Task<PaginatedList<Log>> GetPaginatedList(int pageIndex, int pageSize)
        {
            var logs = from log in _context.Logs
                       select log;
            return await PaginatedList<Log>.CreateAsync(logs, pageIndex, pageSize);
        }
    }
}
