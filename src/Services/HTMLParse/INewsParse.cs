using Entity;

namespace HTMLParse;

public interface INewsParse {
    public List<NewsItem> GetNews(string url);
}