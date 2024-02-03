using NUnit.Framework;
using Entity;

namespace Entity.Tests {
    [TestFixture]
    public class NewsItemTests {
        [Test]
        public void NewsItem_Title_SetAndGetCorrectly() {
            // Arrange
            string expectedTitle = "Test Title";
            NewsItem newsItem = new NewsItem();

            // Act
            newsItem.Title = expectedTitle;
            string actualTitle = newsItem.Title;

            // Assert
            Assert.AreEqual(expectedTitle, actualTitle);
        }

        [Test]
        public void NewsItem_UrlSlug_SetAndGetCorrectly() {
            // Arrange
            string expectedUrlSlug = "test-url-slug";
            NewsItem newsItem = new NewsItem();

            // Act
            newsItem.UrlSlug = expectedUrlSlug;
            string actualUrlSlug = newsItem.UrlSlug;

            // Assert
            Assert.AreEqual(expectedUrlSlug, actualUrlSlug);
        }

        [Test]
        public void NewsItem_Description_SetAndGetCorrectly() {
            // Arrange
            string expectedDescription = "Test Description";
            NewsItem newsItem = new NewsItem();

            // Act
            newsItem.Description = expectedDescription;
            string actualDescription = newsItem.Description;

            // Assert
            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void NewsItem_CreatedDate_SetAndGetCorrectly() {
            // Arrange
            string expectedCreatedDate = new DateTime(2022, 1, 1).ToString();
            NewsItem newsItem = new NewsItem();

            // Act
            newsItem.CreatedDate = expectedCreatedDate.ToString();
            string actualCreatedDate = newsItem.CreatedDate.ToString();

            // Assert
            Assert.AreEqual(expectedCreatedDate, actualCreatedDate);
        }
    }
}