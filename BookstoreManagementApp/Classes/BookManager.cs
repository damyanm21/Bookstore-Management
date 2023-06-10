using BookstoreManagementApp.Classes.Services;
using BookstoreManagementApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookstoreManagementApp.Classes
{
    public class BookManager : IBookManager
    {
        private readonly AddNewBookService _addNewBookService;
        private readonly CalculateTotalValueService _calculateTotalValueService;
        private readonly DiscountCalculationService _discountCalculationService;
        private readonly DisplayBooksService _displayBooksService;
        private readonly SaveBookCollectionToJsonFileService _saveBookCollectionToJsonFileService;
        private readonly SearchBooksService _searchBooksService;

        public BookManager(
            AddNewBookService addNewBookService,
            CalculateTotalValueService calculateTotalValueService,
            DiscountCalculationService discountCalculationService,
            DisplayBooksService displayBooksService,
            SaveBookCollectionToJsonFileService saveBookCollectionToJsonFileService,
            SearchBooksService searchBooksService)
        {
            _addNewBookService = addNewBookService;
            _calculateTotalValueService = calculateTotalValueService;
            _discountCalculationService = discountCalculationService;
            _displayBooksService = displayBooksService;
            _saveBookCollectionToJsonFileService = saveBookCollectionToJsonFileService;
            _searchBooksService = searchBooksService;
        }

        public void AddNewBook(string name, string author, decimal price, int quantity, string description)
        {
            _addNewBookService.AddNewBook(name, author, price, quantity, description);
        }

        public decimal CalculateTotalValue()
        {
            return _calculateTotalValueService.CalculateTotalValue();
        }

        public decimal DiscountCalculation()
        {
           return _discountCalculationService.DiscountCalculation();
        }

        public void DisplayBooks(StringBuilder output)
        {
            _displayBooksService.DisplayBook(output);
        }

        public string SaveBookCollectionToJsonFile()
        {
            return _saveBookCollectionToJsonFileService.SaveBookCollectionToJsonFile();
        }

        public List<Book> SearchBooks(string keyword)
        {
            return _searchBooksService.SearchBooks(keyword);
        }
    }
}
