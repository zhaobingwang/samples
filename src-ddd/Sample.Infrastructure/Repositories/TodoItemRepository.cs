using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int GetCount()
        {
            return _context.TodoItems.Count();
        }

        public async Task<List<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }
        public async Task<TodoItem> GetByIdAsync(long id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public bool Insert(TodoItem entity)
        {
            _context.TodoItems.Add(entity);
            return _context.SaveChanges() > 0;
        }
    }
}
