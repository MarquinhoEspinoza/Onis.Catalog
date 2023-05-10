using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Onis.Domain.Contracts
{
    public interface IRepository
    {
        public interface IRepository<T> where T : class
        {
            Task CreateAsync(T entity);
            Task<List<T>> GetAllAsync();
            Task<T> GetAsync(int id);
            Task RemoveAsync(T entity);
            Task UpdateAsync(T entity);
        }

    }
}

