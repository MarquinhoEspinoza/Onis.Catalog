using Microsoft.EntityFrameworkCore;
using Onis.Infrastructure.DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Onis.Domain.Contracts.IRepository;

namespace Onis.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CatalogDBContext _dbContext;
        private readonly DbSet<T> _dbSet;
        
        public Repository(CatalogDBContext dbContext)
        {
            this._dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            //if (id>0)
            return await _dbSet.FindAsync(id);
        }
            
        public async Task RemoveAsync(T entity)
        {
            
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
        }

      
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }


    }
}
