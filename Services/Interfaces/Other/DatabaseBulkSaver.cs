using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.Other
{
    internal interface DatabaseBulkSaver
    {
        public int SaveToDatabase<T>();
    }
}
