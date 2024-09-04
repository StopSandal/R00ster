using R00ster.Entities;
using R00ster.Services.Interfaces.Repositories;

namespace R00ster.Services.Interfaces.Other
{
    /// <summary>
    /// Defines the contract for the unit of work, which includes repository properties and a save method.
    /// </summary>
    public interface IUnitOfWork
    {
        public IRepositoryAsync<Joke> JokesRepository { get; }

    }
}
