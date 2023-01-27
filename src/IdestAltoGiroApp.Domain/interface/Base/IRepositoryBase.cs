using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace IdestAltoGiroApp.Domain.Interface.Base;

public interface IRepositoryBase<T> where T : class
    {
        Task<IList<T>> GetAsync(params Expression<Func<T, object>>[] including);
        Task<IList<T>> GetByAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);
        Task<IList<T>> GetByOrderAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> order, bool descending, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);
        Task AddAsync(T entity);
        Task<int> AddReturnIdAsync(T entity);
        Task DeleteAsync(T entity);
        T Update(T entity);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> includeProperties = null);
    }