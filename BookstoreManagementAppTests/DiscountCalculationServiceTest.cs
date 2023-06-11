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
    internal class DiscountCalculationServiceTest
    {
        private Mock<IJsonHandler> _jsonHandlerMock;
        private DiscountCalculationService _discountCalculationService;

        [SetUp]
        public void Setup()
        {
            _jsonHandlerMock = new Mock<IJsonHandler>();
            _discountCalculationService = new DiscountCalculationService(_jsonHandlerMock.Object);
        }

        [Test]
        // Discount calculation with no books. Expected result is zero.
        public void DiscountCalculation_WithNoBooks_ReturnsZero()
        {
            // Arrange
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(new BookData { Books = null });

            // Act
            decimal result = _discountCalculationService.DiscountCalculation();

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        // Discount calculation with books. Expected result: Calculates total value with discounts.
        public void DiscountCalculation_WithBooks_CalculatesTotalValueWithDiscounts()
        {
            // Arrange
            var books = new List<Book>
        {
            new Book { Price = 10, Quantity = 2 },
            new Book { Price = 20, Quantity = 1 },
            new Book { Price = 30, Quantity = 3 }
        };
            var bookData = new BookData { Books = books };
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            decimal result = _discountCalculationService.DiscountCalculation();

            // Assert
            Assert.AreEqual(113.5m, result);
        }

        [Test]
        // Discount calculation with books below $15. Expected result: Lowers the price by 5% for books under $15.
        public void DiscountCalculation_WithBooks_LowersPriceBy5PercentForBooksUnder15()
        {
            // Arrange
            var books = new List<Book>
        {
            new Book { Price = 10, Quantity = 1 },
            new Book { Price = 12, Quantity = 1 }
        };
            var bookData = new BookData { Books = books };
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            _discountCalculationService.DiscountCalculation();

            // Assert
            Assert.AreEqual(9.5m, books[0].Price);
            Assert.AreEqual(11.4m, books[1].Price);
        }

        [Test]
        // Discount calculation with books between $15 and $25. Expected result: Lowers the price by 10% for books between $15 and $25.
        public void DiscountCalculation_WithBooks_LowersPriceBy10PercentForBooksBetween15And25()
        {
            // Arrange
            var books = new List<Book>
        {
            new Book { Price = 18, Quantity = 1 },
            new Book { Price = 22, Quantity = 1 }
        };
            var bookData = new BookData { Books = books };
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            _discountCalculationService.DiscountCalculation();

            // Assert
            Assert.AreEqual(16.2m, books[0].Price);
            Assert.AreEqual(19.8m, books[1].Price);
        }

        [Test]
        // Discount calculation with books above $25. Expected result: Lowers the price by 15% for books above $25.
        public void DiscountCalculation_WithBooks_LowersPriceBy15PercentForBooksAbove25()
        {
            // Arrange
            var books = new List<Book>
        {
            new Book { Price = 30, Quantity = 1 },
            new Book { Price = 40, Quantity = 1 }
        };
            var bookData = new BookData { Books = books };
            _jsonHandlerMock.Setup(mock => mock.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            _discountCalculationService.DiscountCalculation();

            // Assert
            Assert.AreEqual(25.5m, books[0].Price);
            Assert.AreEqual(34m, books[1].Price);
        }
    }
}
