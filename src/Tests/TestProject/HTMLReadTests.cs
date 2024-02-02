using Entity;
using HTMLParse.Abstracts;
using HTMLParse.SiteCollection;

namespace TestProject;

[TestFixture]
public class HTMLReadTests {
    [Test]
    public void Fontanka_GetNews_ValidUrl_ReturnsListOfNewsItems() {
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
    public void Fontanka_GetNews_InvalidUrl_IsEmpty() {
        // Arrange
        string url = "https://www.fail.ru/";
        INewsParse htmlRead = new FontankaHTMLRead();

        // Act & Assert
        Assert.IsEmpty(htmlRead.GetNews(url));
    }

    [Test]
    public void Tass_GetNews_ValidUrl_ReturnsListOfNewsItems() {
        // Arrange
        string url = "https://tass.ru/";
        INewsParse htmlRead = new TassHTMLRead();

        // Act
        var news = htmlRead.GetNews(url);

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
    public void Tass_GetNews_InvalidUrl_IsEmpty() {
        // Arrange
        string url = "https://www.fail.ru/";
        INewsParse htmlRead = new TassHTMLRead();

        // Act & Assert
        Assert.IsEmpty(htmlRead.GetNews(url));
    }
}