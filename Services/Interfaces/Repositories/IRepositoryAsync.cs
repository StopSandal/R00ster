using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.Repositories
{
    /// <summary>
    /// Class represents operations with generic entity
    /// </summary>
    internal interface IRepositoryAsync<T> where T : class
    {
        public Task InsertRangeAsync(IEnumerable<T> items);
        public Task<int> GetCountAsync(Expression<Func<T,bool>>? filter = null);
    }
}
