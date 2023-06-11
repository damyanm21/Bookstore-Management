using BookstoreManagementApp.Classes.Services;
using BookstoreManagementApp.Classes;
using BookstoreManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace BookstoreManagementApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Dependencies
            string jsonFilePath = Const.JsonFileName;
            IJsonHandler jsonHandler = new JsonHandlerService(jsonFilePath);
            AddNewBookService addNewBookService = new AddNewBookService(jsonHandler);
            CalculateTotalValueService calculateTotalValueService = new CalculateTotalValueService(jsonHandler);
            DiscountCalculationService discountCalculationService = new DiscountCalculationService(jsonHandler);
            DisplayBooksService displayBooksService = new DisplayBooksService(jsonHandler);
            SaveBookCollectionToJsonFileService saveBookCollectionToJsonFileService = new SaveBookCollectionToJsonFileService(jsonHandler);
            SearchBooksService searchBooksService = new SearchBooksService(jsonHandler);
            BookData bookData = new BookData();
            StringBuilder output = new StringBuilder();
            

            // Create an instance of the BookManager
            IBookManager bookManager = new BookManager(
                addNewBookService,
                calculateTotalValueService,
                discountCalculationService,
                displayBooksService,
                saveBookCollectionToJsonFileService,
                searchBooksService);

            ConsoleViewValidations validations = new ConsoleViewValidations(bookManager, output);

            // Create an instance of the ConsoleView and run it
            ConsoleView consoleView = new ConsoleView(bookManager, bookData, output, validations);
            consoleView.Run();
        }
    }
}
