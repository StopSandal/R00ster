using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.DatabaseSavers
{
    internal interface IDatabaseBulkSaver<TClass> where TClass : class
    {
        public IAsyncEnumerable<int> SaveToDatabaseAsync(IAsyncEnumerable<TClass> item);
    }
}
