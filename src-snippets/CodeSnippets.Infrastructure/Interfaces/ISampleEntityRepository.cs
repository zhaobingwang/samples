using CodeSnippets.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Infrastructure.Interfaces
{
    public interface ISampleEntityRepository
    {
        Task<SampleEntity> GetAsync(int id);
        Task<List<SampleEntity>> ListAsync();
        Task CreateAsync(SampleEntity entity);
        Task UpdateAsync(SampleEntity entity);
        Task DeleteAsync(SampleEntity entity);
    }
}
