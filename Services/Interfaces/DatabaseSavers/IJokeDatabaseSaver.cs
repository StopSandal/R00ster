using R00ster.Entities;

namespace R00ster.Services.Interfaces.DatabaseSavers
{
    /// <summary>
    /// A bulk save to database for the <see cref="Joke"/>
    /// </summary>
    internal interface IJokeDatabaseSaver : IDatabaseBulkSaver<Joke>
    {
    }
}
