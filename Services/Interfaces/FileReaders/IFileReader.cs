namespace R00ster.Services.Interfaces.FileReaders
{
    /// <summary>
    /// Defines the contract for a service that reads data from a file and returns the data as instances of the specified class type.
    /// </summary>
    /// <typeparam name="TClass">
    /// The type of the class that the file data will be deserialized into.
    /// </typeparam>
    internal interface IFileReader<TClass> where TClass : class, new()
    {
        /// <summary>
        /// Asynchronously reads file and return object of generic type class
        /// </summary>
        /// <param name="pathToFile">
        /// A full path to file.
        /// </param>
        /// <typeparam name="T">Type of read class</typeparam>
        /// <returns></returns>
        IAsyncEnumerable<TClass> ReadAsync(string pathToFile);
    }
}
