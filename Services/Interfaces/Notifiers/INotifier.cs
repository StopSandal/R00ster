namespace R00ster.Services.Interfaces.Notifiers
{
    internal interface INotifier
    {
        public Task NotifyAsync(string userAddress, string subject, string body);
    }
}
