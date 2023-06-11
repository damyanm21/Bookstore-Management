using BookstoreManagementApp.Classes.Services;
using BookstoreManagementApp.Classes;
using BookstoreManagementApp.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementAppTests
{
    internal class CalculateTotalValueServiceTest
    {
        [TestFixture]
        public class CalculateTotalValueServiceTests
        {
            private Mock<IJsonHandler> _jsonHandlerMock;
            private CalculateTotalValueService _calculateTotalValueService;

            [SetUp]
            public void Setup()
            {
                _jsonHandlerMock = new Mock<IJsonHandler>();
                _calculateTotalValueService = new CalculateTotalValueService(_jsonHandlerMock.Object);
            }

            [Test]
            // Test case for calculating the total value when there are no books. The expected result is zero.
            public void CalculateTotalValue_WithNoBooks_ShouldReturnZero()
            {
                // Arrange
                var bookData = new BookData { Books = null };
                _jsonHandlerMock.Setup(x => x.ReadJsonFile<BookData>()).Returns(bookData);

                // Act
                decimal result = _calculateTotalValueService.CalculateTotalValue();

                // Assert
                Assert.AreEqual(0, result);
            }

            [Test]
            // Test case for calculating the total value when there are empty books. The expected result is zero.
            public void CalculateTotalValue_WithEmptyBooks_ShouldReturnZero()
            {
                // Arrange
                var bookData = new BookData { Books = new List<Book>() };
                _jsonHandlerMock.Setup(x => x.ReadJsonFile<BookData>()).Returns(bookData);

                // Act
                decimal result = _calculateTotalValueService.CalculateTotalValue();

                // Assert
                Assert.AreEqual(0, result);
            }

            [Test]
            // Test case for calculating the total value when there is a single book. The expected result is the product of the book's price and quantity.
            public void CalculateTotalValue_WithSingleBook_ShouldReturnCorrectTotalValue()
            {
                // Arrange
                var book = new Book { Price = 10.0m, Quantity = 2 };
                var bookData = new BookData { Books = new List<Book> { book } };
                _jsonHandlerMock.Setup(x => x.ReadJsonFile<BookData>()).Returns(bookData);

                // Act
                decimal result = _calculateTotalValueService.CalculateTotalValue();

                // Assert
                Assert.AreEqual(20.0m, result);
            }

            [Test]
            public void CalculateTotalValue_WithMultipleBooks_ShouldReturnCorrectTotalValue()
            // Test case for calculating the total value when there are multiple books. The expected result is the sum of the products of each book's price and quantity.
            {
                // Arrange
                var books = new List<Book>
                {
                    new Book { Price = 10.0m, Quantity = 2 },
                    new Book { Price = 5.0m, Quantity = 3 },
                    new Book { Price = 8.0m, Quantity = 1 }
                };
                var bookData = new BookData { Books = books };
                _jsonHandlerMock.Setup(x => x.ReadJsonFile<BookData>()).Returns(bookData);

                // Act
                decimal result = _calculateTotalValueService.CalculateTotalValue();

                // Assert
                Assert.AreEqual(43.0m, result);
            }
        }
    }
}
