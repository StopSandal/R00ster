using R00ster.Entities;
using R00ster.Services.Interfaces.Repositories;

namespace R00ster.Services.Interfaces.Other
{
    public interface IUnitOfWork
    {
        public IRepositoryAsync<Joke> JokesRepository { get; }
    }
}
