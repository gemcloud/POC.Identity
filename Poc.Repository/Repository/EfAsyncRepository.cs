using Poc.Repository.Entities;
using Poc.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Poc.Repository.Repository
{
    public class EfAsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {

        #region Fields

        private RepositoryDbContext _dbContext;

        #endregion

        public EfAsyncRepository(RepositoryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region
        protected DbSet<T> DbSet { get; }
        public IQueryable<T> Table => DbSet;
        #endregion

        #region Public Methods

        public ValueTask<T> GetByIdAsync(int id) => _dbContext.Set<T>().FindAsync(id);

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
                        => _dbContext.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task AddAsync(T entity)
        {
            // await _dbContext.AddAsync(entity);
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            // In case AsNoTracking is used
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAllAsync() => _dbContext.Set<T>().CountAsync();

        public Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate)
                                        => _dbContext.Set<T>().CountAsync(predicate);

        #endregion

    }
}
