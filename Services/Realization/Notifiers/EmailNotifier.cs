using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using R00ster.Services.Interfaces.NetworkSender;
using R00ster.Services.Interfaces.Notifiers;


namespace R00ster.Services.Realization.Notifiers
{
    internal class EmailNotifier : IEmailNotifier
    {
        private const string PathToEmailSender = "EmailSettings:SenderEmail";
        
        private readonly IEmailSender _emailSender;

        public EmailNotifier(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task NotifyAsync(string userAddress, string subject, string body)
        {
            var senderAddress = Program.Config.GetValue<string>(PathToEmailSender);

            var message = new MimeMessage();

            message.To.Add(MailboxAddress.Parse(userAddress));
            message.From.Add(MailboxAddress.Parse(senderAddress));
            message.Subject = subject;

            BodyBuilder emailBodyBuilder = new BodyBuilder();
            emailBodyBuilder.TextBody = body;
            message.Body = emailBodyBuilder.ToMessageBody();

            await _emailSender.SendAsync(message);

        }
    }
}
