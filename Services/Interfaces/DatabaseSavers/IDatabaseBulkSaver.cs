namespace R00ster.Services.Interfaces.DatabaseSavers
{
    internal interface IDatabaseBulkSaver<TClass> where TClass : class
    {
        public IAsyncEnumerable<int> SaveToDatabaseAsync(IAsyncEnumerable<TClass> item);
    }
}
