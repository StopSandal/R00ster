namespace R00ster.Services.Interfaces.MainWindowServices
{
    public interface IMainWindowService
    {
        public Task<int> ReadExcelFileWithDbSaveAsync(string pathToFile);
    }
}
