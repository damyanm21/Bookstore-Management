using BookstoreManagementApp.Classes.Services;
using BookstoreManagementApp.Classes;
using BookstoreManagementApp.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BookstoreManagementAppTests
{
    internal class SearchBooksServiceTest
    {
        private SearchBooksService _searchBooksService;
        private Mock<IJsonHandler> _jsonHandlerMock;

        [SetUp]
        public void Setup()
        {
            _jsonHandlerMock = new Mock<IJsonHandler>();
            _searchBooksService = new SearchBooksService(_jsonHandlerMock.Object);
        }

        [Test]
        // Tests the SearchBooks method when the book data is empty. It should return null.
        public void SearchBooks_WhenBookDataIsEmpty_ReturnsNull()
        {
            // Arrange
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(new BookData { Books = new List<Book>() });
            string keyword = "test";

            // Act
            var result = _searchBooksService.SearchBooks(keyword);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        // Tests the SearchBooks method when the keyword matches the title of some books. It should return the matching books.
        public void SearchBooks_WhenKeywordMatchesTitle_ReturnsMatchingBooks()
        {
            // Arrange
            var bookData = new BookData
            {
                Books = new List<Book>
            {
                new Book { Title = "Test Book 1", Author = "Author 1" },
                new Book { Title = "Another Book", Author = "Author 2" },
                new Book { Title = "Test Book 2", Author = "Author 3" }
            }
            };
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(bookData);
            string keyword = "test";

            // Act
            var result = _searchBooksService.SearchBooks(keyword);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Test Book 1", result[0].Title);
            Assert.AreEqual("Test Book 2", result[1].Title);
        }

        [Test]
        // Tests the SearchBooks method when the keyword matches the author of some books. It should return the matching books.
        public void SearchBooks_WhenKeywordMatchesAuthor_ReturnsMatchingBooks()
        {
            // Arrange
            var bookData = new BookData
            {
                Books = new List<Book>
            {
                new Book { Title = "Book 1", Author = "Test Author 1" },
                new Book { Title = "Book 2", Author = "Another Author" },
                new Book { Title = "Book 3", Author = "Test Author 2" }
            }
            };
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(bookData);
            string keyword = "test";

            // Act
            var result = _searchBooksService.SearchBooks(keyword);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Book 1", result[0].Title);
            Assert.AreEqual("Book 3", result[1].Title);
        }
    }
}
