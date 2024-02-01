using System.ServiceModel.Syndication;
using RssParse;

namespace TestProject;

[TestFixture]
public class RssReaderTests {
    private RssReader _rssReader;

    [SetUp]
    public void Setup() {
        string uri = "../../../../../../src/Tests/static/fontanka.rss";
        _rssReader = new RssReader(uri);
    }

    [Test]
    public void GetPosts_ReturnsNonEmptyList() {
        // Act
        IEnumerable<SyndicationItem> posts = _rssReader.GetPosts();

        // Assert
        Assert.IsNotNull(posts);
        Assert.IsTrue(posts.Any());
    }

    [Test]
    public void GetPosts_ReturnsValidSyndicationItems() {
        // Act
        IEnumerable<SyndicationItem> posts = _rssReader.GetPosts();

        // Assert
        foreach (SyndicationItem post in posts) {
            Assert.IsNotNull(post.Title);
            Assert.IsNotNull(post.Summary);
            Assert.IsNotNull(post.Links);
            Assert.IsTrue(post.Links.Any());
        }
    }
}