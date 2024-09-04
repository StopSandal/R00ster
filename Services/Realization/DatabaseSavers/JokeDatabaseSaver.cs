using R00ster.Entities;
using R00ster.Services.Interfaces.DatabaseSavers;
using R00ster.Services.Interfaces.Other;

namespace R00ster.Services.Realization.DatabaseSavers
{
    /// <summary>
    /// A realization of interface <see cref="IJokeDatabaseSaver"./>
    /// </summary>
    internal class JokeDatabaseSaver : IJokeDatabaseSaver
    {
        private const int BunchSize = 2048;
        readonly IUnitOfWork _unitOfWork;
        List<Joke> _bunch = new List<Joke>(BunchSize);

        public JokeDatabaseSaver(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        /// <inheritdoc/>
        public async IAsyncEnumerable<int> SaveToDatabaseAsync(IAsyncEnumerable<Joke> items)
        {


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
            _bunch.Clear();
        }
    }
}
