using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Classes
{
    public class Const
    {
        public const string ErrorLogFileName = "error.log";
        public const string JsonFileName = "BookstoreManagement.json";
        public const string OutputJsonFileName = "BookstoreManagementOutput.json";

        public const string BookAddedSuccess = "Book added successfully.";
        public const string JsonSaveSuccess = "Book collection saved to JSON file successfully.";
        public const string DiscountsApplied = "Discounts are applied.";

        public const string TitleError = "Title cannot exceed 50 characters.";
        public const string AuthorError = "Author cannot exceed 50 characters.";
        public const string PriceError = "Price must be a positive value.";
        public const string QuantityError = "Quantity must be a positive value.";
        public const string DescriptionError = "Description cannot exceed 200 characters.";

        public const string NullTitleError = "Title field cannot be empty.";
        public const string NullAuthorError = "Author field cannot be empty.";
        public const string NullPriceError = "Price field cannot be empty.";
        public const string NullQuantityError = "Quantity field cannot be empty.";

        public const string Error = "Error: ";
        public const string Stacktrace = "Stacktrace: ";
        public const string JsonReadError = "An error occurred while reading the JSON file. ";
        public const string JsonWriteError = "An error occurred while writing the JSON file. ";
        public const string JsonSaveError = "An error occurred while saving the JSON file. ";
        public const string NoBooksFound = "No books found.";
        public const string AddBookError = "There was an error while adding a new book. ";
    }
}
