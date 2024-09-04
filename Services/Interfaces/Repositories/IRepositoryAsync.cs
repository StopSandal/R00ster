using System.Linq.Expressions;

namespace R00ster.Services.Interfaces.Repositories
{
    /// <summary>
    /// Class represents operations with generic entity
    /// </summary>
    public interface IRepositoryAsync<T> where T : class
    {
        public Task InsertRangeAsync(IEnumerable<T> items);
        public Task<int> GetCountAsync(Expression<Func<T, bool>>? filter = null);
    }
}
