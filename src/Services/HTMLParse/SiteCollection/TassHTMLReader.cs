using System.Collections.Concurrent;
using System.Text;
using Entity;
using HtmlAgilityPack;
using HTMLParse.Abstracts;

namespace HTMLParse.SiteCollection;

public class TassHTMLRead: INewsParse {
    private const string _searchDepthMinPage = "//html/body/div/div/div/div/div/div/div/div/a";

    private const string _searchDepthChildPageDate =
        "//html/body/div/div/div/div/div/section/div/article/div/div/div/span";

    private const string _searchDepthChildPageText =
        "//html/body/div/div/div/div/div/section/div/article/div/section/div/div/p";

    public List<NewsItem> GetNews(string _url) {
        ConcurrentBag<NewsItem> news = new ConcurrentBag<NewsItem>();
        HtmlWeb web = new HtmlWeb();
        HtmlDocument doc = web.Load(_url);
        var links = doc.DocumentNode.SelectNodes(_searchDepthMinPage);
        if (links != null) {
            Parallel.ForEach(links,
                (link) =>
                {
                    try {
                        var temp = link.GetClasses();
                        string href = new StringBuilder(_url + link.GetAttributeValue("href", "")).ToString();
                        string innerText = link.InnerText;

                        var innerDoc = web.Load(href);
                        var linksChildDate = innerDoc.DocumentNode.SelectNodes(_searchDepthChildPageDate).Last().InnerText;
                        var linksChildText = innerDoc.DocumentNode.SelectNodes(_searchDepthChildPageText).First().InnerText;
                        news.Add(
                            new NewsItem() {
                                Title = innerText,
                                UrlSlug = href,
                                Description = linksChildText,
                                CreatedDate = DateTime.Parse(linksChildDate)
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
}