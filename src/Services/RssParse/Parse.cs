using System.ServiceModel.Syndication;
using System.Xml;
using Entity;
using Entity.Abstraction;
using RssParse.Abstracts;

namespace RssParse;

public class Parse: IParser, INewsProvider {
    private string _rssUrl;

    public Parse(string rssUrl = "https://tass.ru/rss/v2.xml?sections=MjU%3D") {
        _rssUrl = rssUrl;
    }

    public List<NewsItem> ParseTo() {
        var news = new List<NewsItem>();
        IEnumerable<SyndicationItem> posts = new RssReader(_rssUrl).GetPosts();
        foreach (var post in posts) {
            try {
                var newPost = new NewsItem() {
                    Title = post.Title.Text ?? "",
                    UrlSlug = post.Links.First().ToString() ?? "",
                    Description = post.Summary.Text ?? "",
                    CreatedDate = post.PublishDate.ToString()
                };
                news.Add(newPost);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        return news;
    }

    public async Task<List<NewsItem>> GetNewsAsync<T>() where T : INewsProvider {
        return await Task.Run(() => ParseTo());
    }
}