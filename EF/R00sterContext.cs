using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using R00ster.Entities;
using System.IO;

namespace R00ster.EF
{
    internal class R00sterContext : DbContext
    {
        internal DbSet<Joke> Jokes { get; set; }
        public R00sterContext(DbContextOptions<R00sterContext> options) : base(options)
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }
        }
    }
}
