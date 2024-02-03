namespace Entity.Abstraction;

public interface IRepository<T> {
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetNewsByTextAsync(SelectEntity selectEntity);
}