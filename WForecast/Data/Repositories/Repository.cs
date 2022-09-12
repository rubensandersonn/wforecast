using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using WForecast.Data.Repositories.Interfaces;
using WForecast.Models;

namespace WForecast.Data
{
    public class Repository<T, TDbContext> : IRepository<T>
        where T : Entity
        where TDbContext : WContext
    {
        protected readonly TDbContext _context;
        protected readonly DbSet<T> _currentSet;

        //protected event BeforeChangeDelegate BeforeDelete;

        public Repository(TDbContext ctx)
        {
            _context = ctx;
            _currentSet = _context.Set<T>();
        }

        public Task<T> GetByIdAsNoTrackingAsync(long id)
            => _currentSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && e.IsActive);

        public IQueryable<T> GetAll()
            => _currentSet.Where(e => e.IsActive);

        private void ResetContextState() => _context.ChangeTracker.Entries()
            .Where(e => e.Entity != null).ToList()
            .ForEach(e => e.State = EntityState.Detached);

        public async Task<long> InsertAsync(T entity)
        {
            try
            {
                _currentSet.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;
            }
            catch (Exception ex)
            {
                ResetContextState();
                throw ex;
            }

        }
        public async Task UpdateAsync(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ResetContextState();
                throw ex;
            }
        }
        public async Task DeleteAsync(T entity)
        {
            try
            {
                entity.IsActive = false;
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                await _context.SaveChangesAsync();
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ResetContextState();
                throw ex;
            }
        }

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await _currentSet.AnyAsync(predicate);
        }
        public async Task<T> GetByIdAsync(long id)
        {
            return await _currentSet.FirstOrDefaultAsync(e => e.Id == id && e.IsActive);
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await _currentSet.SingleOrDefaultAsync(match);
        }
        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await _currentSet.Where(e => e.IsActive).Where(match).ToListAsync();
        }
        public async Task<int> CountAsync()
        {
            return await _currentSet.Where(e => e.IsActive).CountAsync();
        }
        public async Task<IList<T>> GetAllIncludeAsync(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _currentSet.Where(e => e.IsActive);

            foreach (var navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            return await dbQuery.AsNoTracking().ToListAsync();
        }
        public async Task<IList<T>> GetIncludeListAsync(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _currentSet.Where(e => e.IsActive);

            foreach (var navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include(navigationProperty);

            dbQuery = dbQuery.AsNoTracking().Where(where).AsQueryable();

            return await dbQuery.ToListAsync();
        }
        
        public async Task<ICollection<T>> PaggedListAsync(int? pageSize, int? page, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _context.Set<T>().Where(e => e.IsActive);

            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                query = query.Include<T, object>(navigationProperty);

            if (page != null && pageSize != null)
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return await query.ToListAsync();
        }
    }
}