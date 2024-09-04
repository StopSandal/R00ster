namespace R00ster.Services.Interfaces.FileReaders
{
    /// <summary>
    /// Defines the contract for a service that reads data from an Excel file 
    /// and returns the data as instances of the specified class type.
    /// </summary>
    internal interface IExcelReader<TClass> : IFileReader<TClass> where TClass : class, new()
    {
    }
}
