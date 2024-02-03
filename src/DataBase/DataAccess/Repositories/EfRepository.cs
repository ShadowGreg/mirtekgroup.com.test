using System.Linq.Expressions;
using DataBase.Entity;
using Entity;
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

    public async Task<IEnumerable<T>> GetAllAsync() {
        var entities = await _dataContext.Set<T>().ToListAsync();

        return entities;
    }

    public async Task<IEnumerable<T>> GetNewsByTextAsync(SelectEntity selectEntity) {
        var entities = new List<T>();
        if (!selectEntity.HeadText.Equals("")) {
            entities.AddRange(
                _dataContext.Set<T>().Where(n => n.Title.Contains(selectEntity.HeadText)).ToList()
            );
        }
        else if (!selectEntity.MainText.Equals("")) {
            entities.AddRange(
                _dataContext.Set<T>().Where(n => n.Title.Contains(selectEntity.HeadText)).ToList()
            );
        }

        return entities;
    }
}