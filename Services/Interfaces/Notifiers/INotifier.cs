namespace R00ster.Services.Interfaces.Notifiers
{
    /// <summary>
    /// Interface defines a contract for sending notifications asynchronously.
    /// </summary>
    internal interface INotifier
    {
        /// <summary>
        /// Sends a notification to the specified user asynchronously.
        /// </summary>
        /// <param name="userAddress">The address (e.g., email) of the user to be notified.</param>
        /// <param name="subject">The subject of the notification.</param>
        /// <param name="body">The content of the notification message.</param>
        /// <returns>A Task that represents the asynchronous operation.</returns>
        public Task NotifyAsync(string userAddress, string subject, string body);
    }

}
