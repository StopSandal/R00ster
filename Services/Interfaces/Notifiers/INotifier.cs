using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Services.Interfaces.Notifiers
{
    internal interface INotifier
    {
        public Task NotifyAsync(string userAddress, string subject, string body);
    }
}
