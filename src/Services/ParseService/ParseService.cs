using DataBase;
using DataBase.Entity;
using Entity;
using Entity.Abstraction;
using HTMLParse.SiteCollection;
using RssParse;

namespace ParseService;

public class ParseService {
    private string _url = "";


    public async Task Parse(string url) {
        _url = url;
        List<NewsItem> newsItems = new List<NewsItem>();
        switch (_url) {
            case string s when s.Contains("rss"):
                newsItems = await GetNewsRSS();
                break;
            case string s when s.Contains("tass") && !s.Contains("rss"):
                newsItems = await GetNewsTass();
                break;
            case string s when s.Contains("fontanka") && !s.Contains("rss"):
                newsItems = await GetNewsFontanka();
                break;
        }

        foreach (NewsItem news in newsItems) {
            try {
                await using var _dataContext = new DataContext();
                var maxId = _dataContext.News.Max(n => n.Id);
                _dataContext.News.Add(new NewsEntity() {
                    Id = ++maxId,
                    Title = news.Title,
                    UrlSlug = news.UrlSlug,
                    Description = news.Description,
                    CreatedDate = news.CreatedDate.ToString(),
                });
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }

    public async Task<List<NewsItem>> GetNewsTass() {
        try {
            return await new TassHTMLRead(_url).GetNewsAsync<TassHTMLRead>();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<NewsItem>> GetNewsFontanka() {
        try {
            return await new FontankaHTMLRead(_url).GetNewsAsync<TassHTMLRead>();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<NewsItem>> GetNewsRSS() {
        try {
            return await new Parse(_url).GetNewsAsync<TassHTMLRead>();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
}