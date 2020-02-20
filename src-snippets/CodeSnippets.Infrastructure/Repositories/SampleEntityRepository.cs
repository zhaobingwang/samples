using CodeSnippets.Infrastructure.Entities;
using CodeSnippets.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CodeSnippets.Infrastructure.Repositories
{
    public class SampleEntityRepository : ISampleEntityRepository
    {
        private readonly SqliteEFContext _dbContext;
        public SampleEntityRepository(SqliteEFContext sqliteEFContext)
        {
            _dbContext = sqliteEFContext ?? throw new ArgumentNullException(nameof(sqliteEFContext));
        }

        public Task CreateAsync(SampleEntity entity)
        {
            _dbContext.SampleEntity.AddAsync(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(SampleEntity entity)
        {
            _dbContext.SampleEntity.Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public Task<SampleEntity> GetAsync(int id)
        {
            return _dbContext.SampleEntity.FindAsync(id).AsTask();
        }

        public Task<List<SampleEntity>> ListAsync()
        {
            return _dbContext.SampleEntity.ToListAsync();
        }

        public Task UpdateAsync(SampleEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }
    }
}
