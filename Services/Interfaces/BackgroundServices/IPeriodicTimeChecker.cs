namespace R00ster.Services.Interfaces.BackgroundServices
{
    internal interface IPeriodicTimeChecker
    {
        public Task OnTimeReached();
    }
}
