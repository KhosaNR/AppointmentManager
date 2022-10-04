using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        void  Update(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> LoadAllWithRelatedAndConditionAsync<TEntity>(Expression<Func<T, bool>> predicate,params Expression<Func<T, object>>[] expressionList);
    }
}
