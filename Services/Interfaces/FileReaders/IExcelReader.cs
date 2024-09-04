﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.FileReaders
{
    internal interface IExcelReader<TClass> : IFileReader<TClass> where TClass : class, new()
    {
    }
}
