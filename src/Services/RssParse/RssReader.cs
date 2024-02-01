using System.ServiceModel.Syndication;
using System.Xml;
using RssParse.Abstracts;

namespace RssParse;

public class RssReader : IPostGetter {
    private readonly SyndicationFeed _feed;

    public RssReader(string rssUrl = "https://tass.ru/rss/v2.xml?sections=MjU%3D") {
        try {
            var reader = XmlReader.Create(rssUrl);
            _feed = SyndicationFeed.Load(reader);
        }
        catch (Exception e) {
            throw new Exception(e.Message + " " + rssUrl);
        }
    }

    public IEnumerable<SyndicationItem> GetPosts() {
        return _feed.Items;
    }
}