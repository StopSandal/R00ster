using R00ster.Entities;
using R00ster.Services.Interfaces.Repositories;
using R00ster.Services.Realization.FileReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.Other
{
    internal interface IUnitOfWork
    {
        public IRepositoryAsync<Joke> JokesRepository { get; }
    }
}
