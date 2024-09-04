namespace R00ster.Services.Interfaces.FileReaders
{
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
