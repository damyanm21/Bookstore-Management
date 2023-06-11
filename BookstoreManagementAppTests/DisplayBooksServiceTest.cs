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
    internal class DisplayBooksServiceTest
    {
        private DisplayBooksService _displayBooksService;
        private Mock<IJsonHandler> _jsonHandlerMock;

        [SetUp]
        public void SetUp()
        {
            _jsonHandlerMock = new Mock<IJsonHandler>();
            _displayBooksService = new DisplayBooksService(_jsonHandlerMock.Object);
        }

        [Test]
        // DisplayBook with no books. The method should display the "NoBooksFound" message when there are no books or an empty book list.

        public void DisplayBook_WithNoBooks_ShouldDisplayNoBooksFoundMessage()
        {
            // Arrange
            var output = new StringBuilder();
            var bookData = new BookData { Books = null };
            _jsonHandlerMock.Setup(j => j.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            _displayBooksService.DisplayBook(output);

            // Assert
            Assert.AreEqual(Const.NoBooksFound, output.ToString().Trim());
        }

        [Test]
        // DisplayBook with a single book. The method should display the book information for a single book.
        public void DisplayBook_WithSingleBook_ShouldDisplayBookInformation()
        {
            // Arrange
            var output = new StringBuilder();
            var book = new Book
            {
                ID = 1,
                Title = "Sample Title",
                Author = "John Doe",
                Price = 9.99m,
                Quantity = 5,
                Description = "Sample description"
            };
            var bookData = new BookData { Books = new List<Book> { book } };
            _jsonHandlerMock.Setup(j => j.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            _displayBooksService.DisplayBook(output);

            // Assert
            var expectedOutput = $"{book.ID}  | {book.Title}  | {book.Author}  | {book.Price}  | {book.Quantity}  | {book.Description}";
            Assert.AreEqual(expectedOutput, output.ToString().Trim());
        }

        [Test]
        // DisplayBook with multiple books. The method should display all book information for multiple books.
        public void DisplayBook_WithMultipleBooks_ShouldDisplayAllBookInformation()
        {
            // Arrange
            var output = new StringBuilder();
            var books = new List<Book>
        {
            new Book { ID = 1, Title = "Book 1", Author = "Author 1", Price = 9.99m, Quantity = 5, Description = "Description 1" },
            new Book { ID = 2, Title = "Book 2", Author = "Author 2", Price = 14.99m, Quantity = 3, Description = "Description 2" },
            new Book { ID = 3, Title = "Book 3", Author = "Author 3", Price = 19.99m, Quantity = 8, Description = "Description 3" }
        };
            var bookData = new BookData { Books = books };
            _jsonHandlerMock.Setup(j => j.ReadJsonFile<BookData>()).Returns(bookData);

            // Act
            _displayBooksService.DisplayBook(output);

            // Assert
            var expectedOutput = new StringBuilder();
            foreach (var book in books)
            {
                expectedOutput.AppendLine($"{book.ID}  | {book.Title}  | {book.Author}  | {book.Price}  | {book.Quantity}  | {book.Description}");
            }
            Assert.AreEqual(expectedOutput.ToString().Trim(), output.ToString().Trim());
        }

    }
}
