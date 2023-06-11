using BookstoreManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes.Services
{
    public class ConsoleViewValidations
    {
        private readonly IBookManager _bookManager;
        private readonly StringBuilder _output;

        public ConsoleViewValidations(IBookManager bookManager, StringBuilder output)
        {
            _bookManager = bookManager;
            _output = output;
        }

        public void DisplayBooks()
        {
            _output.Clear();
            _bookManager.DisplayBooks(_output);
            Console.WriteLine("ID |      Title          |        Author        |   Price     | Quantity  |    Description");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------");
            Console.WriteLine(_output.ToString());
        }

        public void SearchBooks()
        {
            Console.Write("Enter the keyword to search: ");
            string keyword = Console.ReadLine();
            Console.WriteLine();
            List<Book> searchResults = _bookManager.SearchBooks(keyword);
            if (searchResults != null && searchResults.Count > 0)
            {
                foreach (var book in searchResults)
                {
                    Console.WriteLine($"ID: {book.ID}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author}");
                    Console.WriteLine($"Price: {book.Price}");
                    Console.WriteLine($"Quantity: {book.Quantity}");
                    Console.WriteLine($"Description: {book.Description}");
                }
            }
            else
            {
                Console.WriteLine(Const.NoBooksFound);
            }
        }

        public void AddNewBook()
        {
            Console.Write("Enter the title of the book: ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine(Const.NullTitleError);
                return;
            }
            Console.Write("Enter the author of the book: ");
            string author = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(author))
            {
                Console.WriteLine(Const.NullAuthorError);
                return;
            }
            Console.Write("Enter the price of the book: ");
            decimal price;
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine(Const.NullPriceError);
                return;
            }
            Console.Write("Enter the quantity of the book: ");
            int quantity;
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine(Const.NullQuantityError);
                return;
            }
            Console.Write("Enter the description of the book: ");
            string description = Console.ReadLine();
            Console.WriteLine();
            _bookManager.AddNewBook(title, author, price, quantity, description);
        }

        public void CalculateTotalValue()
        {
            decimal totalValue = _bookManager.CalculateTotalValue();
            Console.WriteLine($"Total Value: ${totalValue}");
        }

        public void DiscountCalculation()
        {
            _bookManager.DiscountCalculation();
            Console.WriteLine("Discounts applied.");
        }

        public void SaveToNewJsonFile()
        {
            string saveMessage = _bookManager.SaveBookCollectionToJsonFile();
            Console.WriteLine(saveMessage);
        }

    }
}
