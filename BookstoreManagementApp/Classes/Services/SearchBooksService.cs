using BookstoreManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes.Services
{
    public class SearchBooksService
    {
        private readonly IJsonHandler _jsonHandler;
        public SearchBooksService(IJsonHandler jsonHandler)
        {
            _jsonHandler = jsonHandler;
        }
        public List<Book> SearchBooks(string keyword)
        {
            var bookData = _jsonHandler.ReadJsonFile<BookData>();
            var books = bookData?.Books;

            if (books != null && books.Count > 0)
            {
                // Filter the books based on the keyword in the title or author fields
                var searchResults = books.Where(book =>
                    book.Title.ToLower().Contains(keyword.ToLower()) ||
                    book.Author.ToLower().Contains(keyword.ToLower())
                ).ToList();

                return searchResults;
            }
            else
            {
                return null;
            }
        }
    }
}
