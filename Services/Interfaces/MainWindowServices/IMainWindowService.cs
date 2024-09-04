using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.MainWindowServices
{
    public interface IMainWindowService
    {
        public Task<int> ReadExcelFileWithDbSaveAsync(string pathToFile);
    }
}
