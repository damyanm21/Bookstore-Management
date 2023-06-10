using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreManagementApp.Interfaces;
using Newtonsoft.Json;

namespace BookstoreManagementApp.Classes.Services
{
    public class AddNewBookService
    {
        private readonly IJsonHandler _jsonHandler;
        public AddNewBookService(IJsonHandler jsonHandler)
        {
            _jsonHandler = jsonHandler;
        }
        public bool AddNewBook(string title, string author, decimal price, int quantity, string description)
        {
            try
            {
                // Validate input values using Book class's property validations
                var newBook = new Book
                {
                    Title = title,
                    Author = author,
                    Price = price,
                    Quantity = quantity,
                    Description = description
                };

                var bookData = _jsonHandler.ReadJsonFile<BookData>();
                var books = bookData?.Books;

                if (books != null)
                {
                    int newId = books?.Max(b => b.ID) + 1 ?? 1;

                    newBook.ID = newId;

                    books.Add(newBook);

                    // Serialize the updated book collection to JSON
                    string updatedJson = JsonConvert.SerializeObject(bookData, Formatting.Indented);

                    // Write the JSON back to the file
                    File.WriteAllText(Const.JsonFileName, updatedJson);

                    return true;
                }
            }
            catch (ArgumentException ex)
            {
                // Handle ArgumentExceptions thrown from property validations
                Console.WriteLine(Const.AddBookError + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle any other exceptions that might occur
                Console.WriteLine(Const.AddBookError + ex.Message);
            }

            return false;
        }
    }
}
