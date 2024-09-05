using R00ster.Services.Interfaces.DatabaseSavers;
using R00ster.Services.Interfaces.FileReaders;
using R00ster.Services.Interfaces.MainWindowServices;
using R00ster.Services.Interfaces.Notifiers;
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
        IEmailNotifier _emailNotifier;

        public MainWindowService(IJokesExcelReader excelReader, IJokeDatabaseSaver databaseBulkSaver, IEmailNotifier emailNotifier)
        {
            _excelReader = excelReader;
            _databaseBulkSaver = databaseBulkSaver;
            _emailNotifier = emailNotifier;
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

        /// <inheritdoc/>
        public async Task SendEmailMessage(string userAddress, string subject, string body)
        {
            await _emailNotifier.NotifyAsync(userAddress, subject, body);
        }
    }
}
