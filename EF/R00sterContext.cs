using Microsoft.EntityFrameworkCore;
using R00ster.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.EF
{
    internal class R00sterContext : DbContext
    {
        internal DbSet<Joke> Jokes { get; set; }
        public R00sterContext(DbContextOptions<R00sterContext> options) : base(options)
        {
        }
    }
}
