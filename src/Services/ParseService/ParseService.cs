using DataBase;
using Entity;

namespace ParseService;

public class ParseService {
    private DataContext _dataContext;

    public ParseService() {
        _dataContext = new DataContext();
    }

    public async Task Parse(string url) { }

    public async Task<List<NewsItem>> GetNews<T>() {
        return await T.GetNews;
    }
}