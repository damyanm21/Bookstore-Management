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
        private readonly ConsoleViewValidations _validations;
        private readonly BookData _bookData;

        public ConsoleView(IBookManager bookManager, BookData bookData, StringBuilder output, ConsoleViewValidations validations)
        {
            _bookManager = bookManager;
            _bookData = bookData;
            _output = output;
            _validations = validations;
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
                        _validations.DisplayBooks();
                        break;
                    case Menu.SearchBooks:
                        _validations.SearchBooks();
                        break;
                    case Menu.AddNewBook:
                        _validations.AddNewBook();
                        break;
                    case Menu.CalculateTotalValue:
                        _validations.CalculateTotalValue();
                        break;
                    case Menu.ApplyDiscounts:
                        _validations.DiscountCalculation();
                        break;
                    case Menu.SaveToNewJsonFile:
                        _validations.SaveToNewJsonFile();
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