using MimeKit;

namespace R00ster.Services.Interfaces.NetworkSender
{
    internal interface IEmailSender
    {
        Task SendAsync(MimeMessage? message);
    }
}
