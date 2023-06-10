using BookstoreManagementApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes.Services
{
    public class DiscountCalculationService
    {
        private readonly IJsonHandler _jsonHandler;
        public DiscountCalculationService(IJsonHandler jsonHandler)
        {
            _jsonHandler = jsonHandler;
        }

        public decimal DiscountCalculation()
        {
            var bookData = _jsonHandler.ReadJsonFile<BookData>();
            var books = bookData?.Books;
            decimal totalValue = 0;


            if (books != null && books.Count > 0)
            {
                foreach (var book in books)
                {
                    if (book.Price < 15)
                    {
                        book.Price -= book.Price * 0.05m;
                    }
                    else if (book.Price >= 15 && book.Price <= 25)
                    {
                        book.Price -= book.Price * 0.1m;
                    }
                    else if (book.Price > 25)
                    {
                        book.Price -= book.Price * 0.15m;
                    }
                    totalValue += book.Price * book.Quantity;
                }
                

                // Serialize the updated book collection to JSON
                string updatedJson = JsonConvert.SerializeObject(bookData, Formatting.Indented);

                // Write the JSON back to the file
                File.WriteAllText(Const.JsonFileName, updatedJson);
                return totalValue;
            }
            else
            {
                return 0;
            }
        }
    }
}
