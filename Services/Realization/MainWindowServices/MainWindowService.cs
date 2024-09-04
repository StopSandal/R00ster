using R00ster.Entities;
using R00ster.Services.Interfaces.DatabaseSavers;
using R00ster.Services.Interfaces.FileReaders;
using R00ster.Services.Interfaces.Other;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.MainWindowServices
{
    internal class MainWindowService : IMainWindowService
    {
        IJokesExcelReader _ExcelReader;
        IJokeDatabaseSaver _databaseBulkSaver;

        public MainWindowService(IJokesExcelReader excelReader, IJokeDatabaseSaver databaseBulkSaver)
        {
            _ExcelReader = excelReader;
            _databaseBulkSaver = databaseBulkSaver;
        }

        public async Task<int> ReadExcelFileWithDbSaveAsync(string pathToFile)
        {
            var TimeBefore = DateTime.Now;
            var totalSavedCount = 0;

            var jokesList = _ExcelReader.ReadAsync(pathToFile);
            var totalCountList = _databaseBulkSaver.SaveToDatabaseAsync(jokesList);

            await foreach (var item in totalCountList)
                totalSavedCount += item;

            Debug.WriteLine($"Spend time to read and save {totalSavedCount} records is {DateTime.Now - TimeBefore}");
            return totalSavedCount;
        }
    }
}
