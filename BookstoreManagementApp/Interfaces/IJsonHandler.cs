using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreManagementApp.Interfaces
{
    public interface IJsonHandler
    {
        /// <summary>
        /// Reads the JSON file and deserializes it to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to deserialize the JSON data to.</typeparam>
        /// <returns>The deserialized object.</returns>
        T ReadJsonFile<T>();

        /// <summary>
        /// Serializes the specified data object and writes it to a JSON file.
        /// </summary>
        /// <typeparam name="T">The type of the data object.</typeparam>
        /// <param name="data">The data object to serialize and write to the JSON file.</param>
        void WriteJsonFile<T>(T data);
    }
}
