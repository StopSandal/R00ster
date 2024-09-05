using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using R00ster.Constants;
using R00ster.Services.Interfaces.NetworkSender;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace R00ster.Services.Realization.NetworkSender
{
    /// <summary>
    /// Class that responsible for Sending an email message.
    /// </summary>
    internal class EmailSender : IEmailSender
    {
        /// <inheritdoc/>
        public async Task SendAsync(MimeMessage? message)
        {
            var senderAddress = Program.Config.GetValue<string>(SettingsPathConstants.PathToEmailSender);
            var senderPassword = Program.Config.GetValue<string>(SettingsPathConstants.PathToEmailSenderPassword);
            var smtpServerAddress = Program.Config.GetValue<string>(SettingsPathConstants.PathToEmailSmtpServer);
            var smtpPortNumber = Program.Config.GetValue<int>(SettingsPathConstants.PathToEmailSmtpPort);

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
