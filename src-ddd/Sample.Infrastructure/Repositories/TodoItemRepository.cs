using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class TodoItemRepository
    {
        private readonly SampleContext _context;
        public TodoItemRepository(SampleContext context)
        {
            _context = context ?? throw new ArgumentNullException($"{nameof(context)}");
        }
        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }
    }
}
