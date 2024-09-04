using R00ster.Entities;
using R00ster.Services.Interfaces.DatabaseSavers;
using R00ster.Services.Interfaces.Other;
using R00ster.Services.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Realization.Other
{
    internal class JokeDatabaseSaver : IJokeDatabaseSaver
    {
        private const int BunchSize = 128;
        readonly IUnitOfWork _unitOfWork;

        public JokeDatabaseSaver(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public async IAsyncEnumerable<int> SaveToDatabaseAsync(IAsyncEnumerable<Joke> items)
        {
            var _bunch = new List<Joke>(BunchSize);

            await foreach (var item in items)
            {
                _bunch.Add(item);
                if (_bunch.Count == BunchSize)
                {
                    await _unitOfWork.JokesRepository.InsertRangeAsync(_bunch);
                    _bunch.Clear();
                    yield return BunchSize;
                }
            }

            if (_bunch.Any())
            {
                await _unitOfWork.JokesRepository.InsertRangeAsync(_bunch);
                yield return _bunch.Count;
            }
        }
    }
}
