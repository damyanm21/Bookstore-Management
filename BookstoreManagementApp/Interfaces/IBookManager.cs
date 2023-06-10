using BookstoreManagementApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Interfaces
{
    public interface IBookManager
    {
        /// <summary>
        /// Displays all books in the books collection.
        /// </summary>
        void DisplayBooks(StringBuilder output);

        /// <summary>
        /// Searches for book in the books collection.
        /// </summary>
        List<Book> SearchBooks(string keyword);

        /// <summary>
        /// Adds a new book in the collection.
        /// </summary>
        void AddNewBook(string name, string author, decimal price, int quantity, string description);

        /// <summary>
        /// Calculates the total value of the books collection.
        /// </summary>
        decimal CalculateTotalValue();

        /// <summary>
        /// Calculates the discount for the books in the book collection.
        /// </summary>
        decimal DiscountCalculation();

        /// <summary>
        /// Saves the book collection to a JSON file.
        /// </summary>
        string SaveBookCollectionToJsonFile();
    }
}
