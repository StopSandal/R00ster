using R00ster.Entities;

namespace R00ster.Services.Interfaces.FileReaders
{
    /// <summary>
    ///  Defines the contract for a service that reads data from an Excel file 
    ///  and returns the data as instance of <see cref="Joke">.
    /// </summary>
    internal interface IJokesExcelReader : IExcelReader<Joke>
    {
    }
}
