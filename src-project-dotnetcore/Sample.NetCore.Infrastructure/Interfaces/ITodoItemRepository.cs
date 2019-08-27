using Sample.NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.NetCore.Infrastructure.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<TodoItem> GetAsync(int id);
        Task<List<TodoItem>> ListAsync();
        Task AddAsync(TodoItem todoItem);
        Task UpdateAsync(TodoItem todoItem);
        Task DeleteAsync(TodoItem todoItem);
    }
}
