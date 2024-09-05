using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using R00ster.Constants;
using R00ster.Services.Interfaces.BackgroundServices;
using R00ster.Services.Interfaces.MainWindowServices;

namespace R00ster.Services.Realization.BackgroundServices
{
    internal class PeriodicTimeChecker : BackgroundService, IPeriodicTimeChecker
    {
        private TimeSpan _targetTime = Program.Config.GetValue<TimeSpan>(SettingsPathConstants.PathToTimeOfExecuting);

        private readonly IMainWindowService _mainWindowService;

        public PeriodicTimeChecker(IMainWindowService mainWindowService)
        {
            _mainWindowService = mainWindowService;
        }

        public async Task OnTimeReached()
        {
            var userEmail = Program.Config.GetValue<string>(SettingsPathConstants.PathToUserEmail);

            await _mainWindowService.SendEmailMessage(userEmail);
        }

        protected async override Task ExecuteAsync(CancellationToken cancellingToken)
        {
            while (!cancellingToken.IsCancellationRequested)
            {
                var currentTime = DateTime.Now.TimeOfDay;
                if (currentTime.Hours == _targetTime.Hours && currentTime.Minutes == _targetTime.Minutes)
                {
                    await OnTimeReached();
                }
                await Task.Delay(TimeSpan.FromMinutes(1), cancellingToken);
            }
        }
    }
}
