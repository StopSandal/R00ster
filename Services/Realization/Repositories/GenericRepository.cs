﻿using Microsoft.EntityFrameworkCore;
using R00ster.EF;
using R00ster.Services.Interfaces.Repositories;

namespace R00ster.Services.Realization.Repositories
{
    /// <summary>
    /// Generic repository class with simple action for any entity
    /// </summary>
    /// <typeparam name="T">An entity class</typeparam>
    internal class GenericRepository<T> : IRepositoryAsync<T> where T : class
    {
        private R00sterContext _context;

        public GenericRepository(R00sterContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<int> GetCountAsync(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            var query = _context.Set<T>().AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            return await query.CountAsync();

        }

        /// <inheritdoc/>
        public async Task InsertRangeAsync(IEnumerable<T> items)
        {
            await _context.AddRangeAsync(items);
            _context.SaveChanges();
        }
    }
}
