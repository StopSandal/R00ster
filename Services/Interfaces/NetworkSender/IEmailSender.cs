using MimeKit;

namespace R00ster.Services.Interfaces.NetworkSender
{
    /// <summary>
    /// Interface defines a contract for sending emails asynchronously.
    /// </summary>
    internal interface IEmailSender
    {
        /// <summary>
        /// Sends an email message asynchronously.
        /// </summary>
        /// <param name="message">The email message to be sent. Can be null.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        Task SendAsync(MimeMessage? message);
    }

}
