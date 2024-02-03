using System.Collections.Concurrent;
using System.Text;
using Entity;
using Entity.Abstraction;
using HtmlAgilityPack;
using HTMLParse.Abstracts;

namespace HTMLParse.SiteCollection;

public class TassHTMLRead: INewsParse, INewsProvider {
    private string _url;
    private const string _searchDepthMinPage = "//html/body/div/div/div/div/div/div/div/div/a";

    private const string _searchDepthChildPageDate =
        "//html/body/div/div/div/div/div/section/div/article/div/div/div/span";

    private const string _searchDepthChildPageText =
        "//html/body/div/div/div/div/div/section/div/article/div/section/div/div/p";

    public TassHTMLRead(string url) {
        _url = url;
    }

    public List<NewsItem> GetNews() {
        ConcurrentBag<NewsItem> news = new ConcurrentBag<NewsItem>();
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(_url);
        var links = doc.DocumentNode.SelectNodes(_searchDepthMinPage);
        if (links != null) {
            ///TODO переделать имплементацию для тасс
            Parallel.ForEach(links,
                (link) =>
                {
                    try {
                        var temp = link.GetClasses();
                        string href = new StringBuilder(_url + link.GetAttributeValue("href", "")).ToString();
                        string innerText = link.InnerText;

                        var innerDoc = web.Load(href);
                        var linksChildDate = innerDoc.DocumentNode.SelectNodes(_searchDepthChildPageDate).Last()
                            .InnerText;
                        var linksChildText = innerDoc.DocumentNode.SelectNodes(_searchDepthChildPageText).First()
                            .InnerText;
                        news.Add(
                            new NewsItem() {
                                Title = innerText,
                                UrlSlug = href,
                                Description = linksChildText,
                                CreatedDate = linksChildDate
                            }
                        );
                    }
                    catch (Exception e) {
                        Console.WriteLine(e);
                    }
                });
        }

        return news.ToList();
    }

    public Task<List<NewsItem>> GetNewsAsync<T>() where T : INewsProvider {
        return Task.Run(GetNews);
    }
}