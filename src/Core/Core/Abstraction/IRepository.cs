﻿using System.Linq.Expressions;

namespace Entity.Abstraction; 

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync();
        
    Task<T> GetByIdAsync(Guid id);
        
    Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids);
        
    Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate);
        
    Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}
