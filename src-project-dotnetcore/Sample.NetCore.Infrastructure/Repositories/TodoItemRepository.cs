using Microsoft.EntityFrameworkCore;
using Sample.NetCore.Domain.Entities;
using Sample.NetCore.Infrastructure.Data;
using Sample.NetCore.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.NetCore.Infrastructure.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly PostgreSQLContext _dbContext;
        public TodoItemRepository(PostgreSQLContext postgreSQLContext)
        {
            _dbContext = postgreSQLContext ?? throw new ArgumentNullException($"{nameof(postgreSQLContext)}");
        }

        public Task AddAsync(TodoItem entity)
        {
            _dbContext.TodoItems.AddAsync(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<TodoItem> GetAsync(int id)
        {
            return _dbContext.TodoItems
                .Include(t => t.Steps)
                .FirstOrDefaultAsync(t => t.ID == id);
        }

        public Task<List<TodoItem>> ListAsync()
        {
            return _dbContext.TodoItems
                .Include(t => t.Steps)
                .OrderByDescending(t => t.ModifyTime)
                .ToListAsync();
        }

        public Task UpdateAsync(TodoItem entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}
