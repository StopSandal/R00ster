using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R00ster.Services.Interfaces.NetworkSender
{
    internal interface IEmailSender
    {
        Task SendAsync(MimeMessage? message);
    }
}
