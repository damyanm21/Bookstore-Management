using BookstoreManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes.Services
{
    public class DisplayBooksService
    {
        private readonly IJsonHandler _jsonHandler;
        public DisplayBooksService(IJsonHandler jsonHandler)
        {
            _jsonHandler = jsonHandler;
        }

        public void DisplayBook(StringBuilder output)
        {
            var bookData = _jsonHandler.ReadJsonFile<BookData>();
            var books = bookData?.Books;

            if (books != null && books.Count > 0)
            {
                foreach (var book in books)
                {
                    output.AppendLine($"{book.ID}  | {book.Title}  | {book.Author}  | {book.Price}  | {book.Quantity}  | {book.Description ?? ""}");
                }
            }
            else
            {
                output.AppendLine(Const.NoBooksFound);
            }
        }
    }
}
