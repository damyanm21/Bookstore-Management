using BookstoreManagementApp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookstoreManagementApp.Classes.Services
{
    public class SaveBookCollectionToJsonFileService
    {
        private readonly IJsonHandler _jsonHandler;
        public SaveBookCollectionToJsonFileService(IJsonHandler jsonHandler)
        {
            _jsonHandler = jsonHandler;
        }
        public string SaveBookCollectionToJsonFile()
        {
            try
            {
                var bookData = _jsonHandler.ReadJsonFile<BookData>();

                // Serialize the book collection to JSON
                string jsonOutput = JsonConvert.SerializeObject(bookData, Formatting.Indented);

                // Write the JSON to a new file
                File.WriteAllText(Const.OutputJsonFileName, jsonOutput);

                return Const.JsonSaveSuccess;
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new Exception(Const.JsonSaveError + $"{ex.Message}");
            }
        }

        private void LogError(Exception ex)
        {
            string errorMessage = $"[{DateTime.Now}] Error: {ex.Message}\nStackTrace: {ex.StackTrace}";
            File.AppendAllText(Const.ErrorLogFileName, errorMessage);
        }
    }
}
