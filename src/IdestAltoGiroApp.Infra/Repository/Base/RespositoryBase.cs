using System.Linq.Expressions;
using IdestAltoGiroApp.Domain.Entity.Base;
using IdestAltoGiroApp.Domain.Interface.Base;
using Microsoft.EntityFrameworkCore;

namespace IdestAltoGiroApp.Infra.Repository.Base;

public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
{
     protected readonly DbContext _context;

    public RepositoryBase(DbContext context)
    {
        _context = context;

    }
    public async  Task AddAsync(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
    }

    public  async Task<int> AddReturnIdAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);

            return entity.Id;
    }

    public async Task DeleteAsync(T entity)
    {
       T existing = await GetByIdAsync(x => x.Id.Equals(entity.Id));
            if (existing != null) _context.Set<T>().Remove(existing);
    }

    public async Task<IList<T>> GetAsync(params Expression<Func<T, object>>[] including)
    {
       IQueryable<T> query = _context.Set<T>();

            if (including != null)
            {
                including.ToList().ForEach(include =>
                {
                    if (include != null)
                        query = query.Include(include);

                 });
                
            }

            return await query.ToListAsync();
    }

    public async Task<IList<T>> GetByAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> includeProperties = null)
    {
        IQueryable<T> query = _context.Set<T>().Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties(query);
            }
            return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> includeProperties = null)
    {
       IQueryable<T> query = _context.Set<T>().Where(predicate);
            if (includeProperties != null)
            {
                query = includeProperties(query);
            }
            return await query.FirstOrDefaultAsync();
    }

    public async Task<IList<T>> GetByOrderAsync<TKey>(System.Linq.Expressions.Expression<Func<T, bool>> predicate, System.Linq.Expressions.Expression<Func<T, TKey>> order, bool descending, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> includeProperties = null)
    {
        IQueryable<T> query;

            if (!descending)
            {
                query = _context.Set<T>().Where(predicate).OrderBy(order);
                if (includeProperties != null)
                {
                    query = includeProperties(query);
                }
            }
            else
            {
                query = _context.Set<T>().Where(predicate).OrderByDescending(order);
                if (includeProperties != null)
                {
                    query = includeProperties(query);
                }
            }


            return await query.ToListAsync();
    }

    public T Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;

        return entity;
    }
}
