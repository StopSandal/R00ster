using System.Linq.Expressions;

namespace R00ster.Services.Interfaces.Repositories
{
    /// <summary>
    /// Class represents operations with generic entity
    /// </summary>
    public interface IRepositoryAsync<T> where T : class
    {
        /// <summary>
        /// Asynchronously inserts to db a bunch of entities.
        /// </summary>
        /// <param name="items">A bunch of entities</param>
        /// <returns>A task that represents an asynchronous operation</returns>
        public Task InsertRangeAsync(IEnumerable<T> items);

        /// <summary>
        ///  Asynchronously get a count of entities at database.
        /// </summary>
        /// <param name="filter">The filtering expression to entities set</param>
        /// <returns>A count of matched by criteria entites</returns>
        public Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null);
    }
}
