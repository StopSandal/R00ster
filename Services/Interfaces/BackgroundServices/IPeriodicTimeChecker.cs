using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.BackgroundServices
{
    internal interface IPeriodicTimeChecker
    {
        public Task OnTimeReached();
    }
}
