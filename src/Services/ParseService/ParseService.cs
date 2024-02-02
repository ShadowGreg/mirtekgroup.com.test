using DataBase;
using DataBase.Entity;
using Entity;
using Entity.Abstraction;
using HTMLParse.SiteCollection;
using RssParse;

namespace ParseService;

public class ParseService {
    private DataContext _dataContext;
    private string _url = "";

    public ParseService() {
        _dataContext = new DataContext();
    }

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

        try {
            foreach (NewsItem news in newsItems) {
                await _dataContext.News.AddAsync(new NewsEntity() {
                    Title = news.Title,
                    UrlSlug = news.UrlSlug,
                    Description = news.Description,
                    CreatedDate = news.CreatedDate,
                });
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<NewsItem>> GetNewsTass() {
        try {
            await Task.Delay(34_400_000);
            return await new TassHTMLRead(_url).GetNewsAsync<TassHTMLRead>();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<NewsItem>> GetNewsFontanka() {
        try {
            await Task.Delay(34_400_000);
            return await new FontankaHTMLRead(_url).GetNewsAsync<TassHTMLRead>();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<NewsItem>> GetNewsRSS() {
        try {
            await Task.Delay(34_400_000);
            return await new Parse(_url).GetNewsAsync<TassHTMLRead>();
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }
}