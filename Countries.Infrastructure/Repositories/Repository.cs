using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Countries.Domain.Repositories;
using Countries.Infrastructure.Persistence;

namespace Countries.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CountryContext _countryContext;

        public Repository(CountryContext countryContext)
        {
            _countryContext = countryContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _countryContext.Set<T>().AddAsync(entity);
            await _countryContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _countryContext.Set<T>().Remove(entity);
            await _countryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _countryContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _countryContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
