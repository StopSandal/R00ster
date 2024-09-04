namespace R00ster.Services.Interfaces.FileReaders
{
    internal interface IExcelReader<TClass> : IFileReader<TClass> where TClass : class, new()
    {
    }
}
