using R00ster.EF;
using R00ster.Entities;
using R00ster.Services.Interfaces.Other;
using R00ster.Services.Interfaces.Repositories;
using R00ster.Services.Realization.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace R00ster.Services.Realization.Other
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly R00sterContext _context;

        public UnitOfWork(R00sterContext context)
        {
            _context = context;
        }

        private IRepositoryAsync<Joke> _JokesRepository;

        public IRepositoryAsync<Joke> JokesRepository { get { return _JokesRepository ??= _JokesRepository = new GenericRepository<Joke>(_context); }   }
    }
}
