using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using R00ster.Services.Interfaces.NetworkSender;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace R00ster.Services.Realization.NetworkSender
{
    internal class EmailSender : IEmailSender
    {
        private const string PathToEmailSender = "EmailSettings:SenderEmail";
        private const string PathToEmailSenderPassword = "EmailSettings:SenderPassword";
        private const string PathToEmailSmtpServer = "EmailSettings:SmtpServer";
        private const string PathToEmailSmtpPort = "EmailSettings:PortNumber";

        public async Task SendAsync(MimeMessage? message)
        {
            var senderAddress = Program.Config.GetValue<string>(PathToEmailSender);
            var senderPassword = Program.Config.GetValue<string>(PathToEmailSenderPassword);
            var smtpServerAddress = Program.Config.GetValue<string>(PathToEmailSmtpServer);
            var smtpPortNumber = Program.Config.GetValue<int>(PathToEmailSmtpPort);

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpServerAddress, smtpPortNumber, SecureSocketOptions.SslOnConnect);
                await client.AuthenticateAsync(senderAddress, senderPassword);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
