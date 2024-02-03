﻿using System.Linq.Expressions;
using DataBase.Entity;
using Entity.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace DataBase.Repositories;

public class EfRepository<T>
    : IRepository<T>
    where T : NewsEntity {
    private readonly DataContext _dataContext;

    public EfRepository(DataContext dataContext) {
        _dataContext = dataContext;
    }

    public Task<IEnumerable<T>> GetAllAsync() {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<T>> GetNewsByTextAsync(string searchingText) {
        throw new NotImplementedException();
    }


    // public async Task<T> GetByIdAsync(Guid id) {
    //     var entity = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    //
    //     return entity;
    // }
    //
    // public async Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids) {
    //     var entities = await _dataContext.Set<T>().Where(x => ids.Contains(x.Id)).ToListAsync();
    //     return entities;
    // }
    //
    // public async Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate) {
    //     return await _dataContext.Set<T>().FirstOrDefaultAsync(predicate);
    // }
    //
    // public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate) {
    //     return await _dataContext.Set<T>().Where(predicate).ToListAsync();
    // }
    //
    // public async Task AddAsync(T entity) {
    //     await _dataContext.Set<T>().AddAsync(entity);
    //     await _dataContext.SaveChangesAsync();
    // }
    //
    // public async Task UpdateAsync(T entity) {
    //     await _dataContext.SaveChangesAsync();
    // }
    //
    // public async Task DeleteAsync(T entity) {
    //     _dataContext.Set<T>().Remove(entity);
    //     await _dataContext.SaveChangesAsync();
}