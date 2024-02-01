using Entity;

namespace RssParse.Abstracts; 

public interface IParser {
    public List<NewsItem> ParseTo();
}