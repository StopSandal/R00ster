namespace R00ster.Services.Interfaces.MainWindowServices
{
    /// <summary>
    /// Defines the contract for a service that handles main window operations.
    /// </summary>
    public interface IMainWindowService
    {
        /// <summary>
        /// Asynchronously reads an Excel file from the specified path and saves the data to the database.
        /// </summary>
        /// <param name="pathToFile">The full path to the Excel file to be read.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of records successfully saved to the database.</returns>
        public Task<int> ReadExcelFileWithDbSaveAsync(string pathToFile);

        public Task SendEmailMessage(string userAddress, string subject, string body);
    }
}
