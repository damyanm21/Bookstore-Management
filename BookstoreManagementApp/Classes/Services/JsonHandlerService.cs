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
    public class JsonHandlerService : IJsonHandler
    {
        private readonly string _jsonFilePath;

        public JsonHandlerService(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public T ReadJsonFile<T>()
        {
            try
            {
                string json = File.ReadAllText(_jsonFilePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new Exception(Const.JsonReadError);
            }
        }

        public void WriteJsonFile<T>(T data)
        {
            try
            {
                string json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(_jsonFilePath, json);
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw new Exception(Const.JsonWriteError);
            }
        }

        private void LogError(Exception ex)
        {
            string errorMessage = $"[{DateTime.Now}] {Const.Error} {ex.Message}\n {Const.Stacktrace} {ex.StackTrace}";
            File.AppendAllText(Const.ErrorLogFileName, errorMessage);
        }
    }
}
