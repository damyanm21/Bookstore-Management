using BookstoreManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes.Services
{
    public class CalculateTotalValueService
    {
        private readonly IJsonHandler _jsonHandler;
        public CalculateTotalValueService(IJsonHandler jsonHandler)
        {
            _jsonHandler = jsonHandler;
        }
        public decimal CalculateTotalValue()
        {
            var bookData = _jsonHandler.ReadJsonFile<BookData>();
            var books = bookData?.Books;

            decimal totalValue = 0;

            if (books != null && books.Count > 0)
            {
                foreach (var book in books)
                {
                    decimal bookValue = book.Price * book.Quantity;
                    totalValue += bookValue;
                }
            }
            return totalValue;
        }
    }
}
