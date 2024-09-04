using R00ster.Services.Interfaces.DatabaseSavers;
using R00ster.Services.Interfaces.FileReaders;
using R00ster.Services.Interfaces.MainWindowServices;
using System.Diagnostics;

namespace R00ster.Services.Realization.MainWindowServices
{
    /// <summary>
    /// A realization of interface <see cref="IMainWindowService"./>
    /// </summary>
    internal class MainWindowService : IMainWindowService
    {
        IJokesExcelReader _excelReader;
        IJokeDatabaseSaver _databaseBulkSaver;

        public MainWindowService(IJokesExcelReader excelReader, IJokeDatabaseSaver databaseBulkSaver)
        {
            _excelReader = excelReader;
            _databaseBulkSaver = databaseBulkSaver;
        }
        /// <inheritdoc/>
        public async Task<int> ReadExcelFileWithDbSaveAsync(string pathToFile)
        {
            var TimeBefore = DateTime.Now;
            var totalSavedCount = 0;

            var jokesList = _excelReader.ReadAsync(pathToFile);
            var totalCountList = _databaseBulkSaver.SaveToDatabaseAsync(jokesList);

            await foreach (var item in totalCountList)
                totalSavedCount += item;

            Debug.WriteLine($"Spend time to read and save {totalSavedCount} records is {DateTime.Now - TimeBefore}");
            return totalSavedCount;
        }
    }
}
