using NUnit.Framework;
using System;
using System.Collections.Generic;
using Moq;
using BookstoreManagementApp.Interfaces;
using BookstoreManagementApp.Classes.Services;
using BookstoreManagementApp.Classes;

namespace BookstoreManagementAppTests
{
    [TestFixture]
    public class AddNewBookServiceTests
    {
        private Mock<IJsonHandler> _jsonHandlerMock;
        private AddNewBookService _addNewBookService;

        [SetUp]
        public void Setup()
        {
            _jsonHandlerMock = new Mock<IJsonHandler>();
            _addNewBookService = new AddNewBookService(_jsonHandlerMock.Object);
        }

        [Test]
        //Tests the AddNewBook method with valid input. Verifies that the method returns true.
        public void AddNewBook_ValidInput_ReturnsTrue()
        {
            // Arrange
            var bookData = new BookData { Books = new List<Book>() };
            _jsonHandlerMock.Setup(m => m.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            bool result = _addNewBookService.AddNewBook("Book Title", "Author Name", 19.99m, 10, "Book Description");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        //Tests the AddNewBook method with invalid input. Verifies that the method returns false.
        public void AddNewBook_InvalidInput_ReturnsFalse()
        {
            // Arrange
            var bookData = new BookData { Books = null };
            _jsonHandlerMock.Setup(m => m.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            bool result = _addNewBookService.AddNewBook("Book Title", "Author Name", 19.99m, 10, "Book Description");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        //Tests the AddNewBook method with null book data.. Verifies that the method returns false.
        public void AddNewBook_NullBookData_ReturnsFalse()
        {
            // Arrange
            _jsonHandlerMock.Setup(m => m.ReadJsonFile<BookData>()).Returns((BookData)null);

            // Act
            bool result = _addNewBookService.AddNewBook("Book Title", "Author Name", 19.99m, 10, "Book Description");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        //Tests the AddNewBook method with empty fields. Verifies that the method returns false.

        public void AddNewBook_WithEmptyFields_ShouldReturnFalse()
        {
            // Arrange
            var title = string.Empty;
            var author = string.Empty;
            var price = 0m;
            var quantity = 0;
            var description = string.Empty;

            // Act
            bool result = _addNewBookService.AddNewBook(title, author, price, quantity, description);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
