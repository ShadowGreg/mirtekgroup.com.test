using Entity;

namespace RssParse.Tests {
    [TestFixture]
    public class ParseTests {
        private Parse _parser;

        [SetUp]
        public void Setup() {
            string uri = "../../../../../../src/Tests/static/fontanka.rss";
            _parser = new Parse(uri);
        }

        [Test]
        public void ParseTo_ReturnsNonEmptyList() {
            // Act
            List<NewsItem> news = _parser.ParseTo();

            // Assert
            Assert.IsNotNull(news);
            Assert.IsTrue(news.Any());
        }

        [Test]
        public void ParseTo_ReturnsValidNewsItems() {
            // Act
            List<NewsItem> news = _parser.ParseTo();

            // Assert
            foreach (NewsItem item in news) {
                Assert.IsNotNull(item.Title);
                Assert.IsNotNull(item.UrlSlug);
                Assert.IsNotNull(item.Description);
                Assert.IsNotNull(item.CreatedDate);
            }
        }
    }
}