using Domain.Interfaces.Persistence;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        protected GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T>  GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.SaveChanges();
        }

        public async Task<IEnumerable<T>> LoadAllWithRelatedAndConditionAsync<TEntity>( Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] expressionList) 
        {
            var query = _context.Set<T>().Where(predicate).AsQueryable();
            foreach (var expression in expressionList)
            {
                query = query.Include(expression);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> LoadAllWithRelatedAsync<TEntity>(params Expression<Func<T, object>>[] expressionList)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var expression in expressionList)
            {
                query = query.Include(expression);
            }
            var test = await query.ToListAsync();
            return await query.ToListAsync();
        }
    }
}
