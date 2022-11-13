using Hamroh_V2.Data.Contexts;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Entities.Clients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hamroh_V2.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal Hamroh_V2DbContext _dbContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(Hamroh_V2DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            EntityEntry entry = await _dbContext.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return (T)entry.Entity;
        }

        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var client = await _dbSet.FirstOrDefaultAsync(predicate);

            if(client == null)
            {
                return false;
            }
            else
            {
                _dbSet.Remove(client);
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            EntityEntry entry = _dbSet.Update(entity);

            await _dbContext.SaveChangesAsync();

            return (T)entry.Entity;
        }
    }
}
