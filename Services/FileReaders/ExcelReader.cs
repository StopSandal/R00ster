using R00ster.Services.Interfaces.FileReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.FileReaders
{
    internal class ExcelReader : IExcelReader
    {
        public IAsyncEnumerable<T> ReadAsync<T>()
        {
            throw new NotImplementedException();
        }
    }
}
