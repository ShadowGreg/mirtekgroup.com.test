namespace Entity.Abstraction;

public interface INewsProvider {
    public Task<List<NewsItem>> GetNewsAsync<T>() where T : INewsProvider;
}