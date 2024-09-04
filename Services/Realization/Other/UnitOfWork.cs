using R00ster.EF;
using R00ster.Entities;
using R00ster.Services.Interfaces.Other;
using R00ster.Services.Interfaces.Repositories;
using R00ster.Services.Realization.Repositories;

namespace R00ster.Services.Realization.Other
{
    /// <summary>
    /// A realization of interface <see cref="IUnitOfWork"./>
    /// </summary>
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly R00sterContext _context;

        public UnitOfWork(R00sterContext context)
        {
            _context = context;
        }

        private IRepositoryAsync<Joke> _JokesRepository;

        public IRepositoryAsync<Joke> JokesRepository { get { return _JokesRepository ??= _JokesRepository = new GenericRepository<Joke>(_context); } }
    }
}
