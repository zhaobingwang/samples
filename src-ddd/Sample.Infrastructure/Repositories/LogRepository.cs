using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
    }
}
