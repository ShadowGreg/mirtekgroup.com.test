using Entity;
using HtmlAgilityPack;
using HTMLParse;
using HTMLParse.SiteCollection;

namespace TestProject;

[TestFixture]
public class HTMLReadTests {
    [Test]
    public void GetNews_ValidUrl_ReturnsListOfNewsItems() {
        // Arrange
        string url = "https://www.fontanka.ru/";
        FontankaHTMLRead fontankaHtmlRead = new FontankaHTMLRead();

        // Act
        var news = fontankaHtmlRead.GetNews(url);

        // Assert
        Assert.IsNotNull(news);
        Assert.IsInstanceOf(typeof(List<NewsItem>), news);
        Assert.IsTrue(news.Count > 0);
        foreach (var item in news) {
            Assert.IsNotNull(item.Title);
            Assert.IsNotNull(item.UrlSlug);
            Assert.IsNotNull(item.Description);
            Assert.IsNotNull(item.CreatedDate);
        }
    }

    [Test]
    public void GetNews_InvalidUrl_IsEmpty() {
        // Arrange
        string url = "https://www.fail.ru/";
        FontankaHTMLRead fontankaHtmlRead = new FontankaHTMLRead();

        // Act & Assert
        Assert.IsEmpty(fontankaHtmlRead.GetNews(url));
    }
}