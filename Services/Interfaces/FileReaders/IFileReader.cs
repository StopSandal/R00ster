using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.FileReaders
{
    internal interface IFileReader
    {
        /// <summary>
        /// Asynchronously reads file and return object of generic type class
        /// </summary>
        /// <typeparam name="T">Type of read class</typeparam>
        /// <returns></returns>
        IAsyncEnumerable<T> ReadAsync<T>();
    }
}
