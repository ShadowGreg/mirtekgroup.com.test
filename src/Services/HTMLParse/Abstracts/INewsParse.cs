using Entity;

namespace HTMLParse.Abstracts;

public interface INewsParse {
    public List<NewsItem> GetNews(string url);
}