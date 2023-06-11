using BookstoreManagementApp.Classes.Services;
using BookstoreManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes
{
    public class ConsoleView
    {
        private readonly IBookManager _bookManager;
        private readonly StringBuilder _output;
        private readonly BookData _bookData;

        public ConsoleView(IBookManager bookManager, BookData bookData, StringBuilder output)
        {
            _bookManager = bookManager;
            _bookData = bookData;
            _output = output;
        }

        public enum Menu
        {
            DisplayBooks = 1,
            SearchBooks = 2,
            AddNewBook = 3,
            CalculateTotalValue = 4,
            ApplyDiscounts = 5,
            SaveToNewJsonFile = 6,
            Exit = 7
        }

        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("========== Bookstore Management ==========");
                Console.WriteLine("1. Display Books");
                Console.WriteLine("2. Search Books");
                Console.WriteLine("3. Add New Book");
                Console.WriteLine("4. Calculate Total Value");
                Console.WriteLine("5. Apply Discounts");
                Console.WriteLine("6. Save to new Json File");
                Console.WriteLine("7. Exit");
                Console.WriteLine();
                Console.Write("Enter your choice (1-7): ");

                Menu menu;
                Enum.TryParse(Console.ReadLine(), out menu);
                switch (menu)
                {
                    case Menu.DisplayBooks:
                        _output.Clear();
                        _bookManager.DisplayBooks(_output);
                        Console.WriteLine("ID |      Title          |        Author        |   Price     | Quantity  |    Description");
                        Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                        Console.WriteLine(_output.ToString());
                        break;
                    case Menu.SearchBooks:
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
                        break;
                    case Menu.AddNewBook:
                        Console.Write("Enter the title of the book: ");
                        string title = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            Console.WriteLine(Const.NullTitleError);
                            break;
                        }
                        Console.Write("Enter the author of the book: ");
                        string author = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(author))
                        {
                            Console.WriteLine(Const.NullAuthorError);
                            break;
                        }
                        Console.Write("Enter the price of the book: ");
                        decimal price;
                        if (!decimal.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine(Const.NullPriceError);
                            break;
                        }
                        Console.Write("Enter the quantity of the book: ");
                        int quantity;
                        if (!int.TryParse(Console.ReadLine(), out quantity))
                        {
                            Console.WriteLine(Const.NullQuantityError);
                            break;
                        }
                        Console.Write("Enter the description of the book: ");
                        string description = Console.ReadLine();
                        Console.WriteLine();
                        _bookManager.AddNewBook(title, author, price, quantity, description);
                        break;
                    case Menu.CalculateTotalValue:
                        decimal totalValue = _bookManager.CalculateTotalValue();
                        Console.WriteLine($"Total Value: ${totalValue}");
                        break;
                    case Menu.ApplyDiscounts:
                        _bookManager.DiscountCalculation();
                        Console.WriteLine("Discounts applied.");
                        break;
                    case Menu.SaveToNewJsonFile:
                        string saveMessage = _bookManager.SaveBookCollectionToJsonFile();
                        Console.WriteLine(saveMessage);
                        break;
                    case Menu.Exit:
                        exit = true;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option (1-7).");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}