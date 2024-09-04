namespace R00ster.Services.Interfaces.DatabaseSavers
{
    /// <summary>
    /// Defines the contract for a service that saves a collection of items to the database in bulk.
    /// </summary>
    /// <typeparam name="TClass">
    /// The type of the class representing the items to be saved to the database. 
    /// </typeparam>
    internal interface IDatabaseBulkSaver<TClass> where TClass : class
    {
        /// <summary>
        /// Asynchronously saves the provided collection of items to the database in bulk.
        /// </summary>
        /// <param name="items">An asynchronous enumerable of items to be saved to the database.</param>
        /// <returns>An asynchronous enumerable of integers representing the number of records saved.</returns>
        public IAsyncEnumerable<int> SaveToDatabaseAsync(IAsyncEnumerable<TClass> items);
    }

}
