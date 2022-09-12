using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using WForecast.Models;

namespace WForecast.Data.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : Entity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsNoTrackingAsync(long id);
        Task<T> GetByIdAsync(long id);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<int> CountAsync();
        Task<long> InsertAsync(T entity);
        Task UpdateAsync(T updated);
        Task DeleteAsync(T entity);
        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> PaggedListAsync(int? pageSize, int? page, params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetAllIncludeAsync(params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetIncludeListAsync(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }
}