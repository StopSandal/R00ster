using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using R00ster.Constants;
using R00ster.Services.Interfaces.MainWindowServices;

namespace R00ster.Services.Realization.BackgroundServices
{
    /// <summary>
    /// Background service that fires every minute with some action. Works even if main app, isn't started.
    /// </summary>
    internal class PeriodicTimeChecker : BackgroundService
    {
        private TimeSpan _targetTime = Program.Config.GetValue<TimeSpan>(SettingsPathConstants.PathToTimeOfExecuting);

        private readonly IMainWindowService _mainWindowService;

        public PeriodicTimeChecker(IMainWindowService mainWindowService)
        {
            _mainWindowService = mainWindowService;
        }

        /// <inheritdoc/>
        public async Task OnTimeReached()
        {
            var userEmail = Program.Config.GetValue<string>(SettingsPathConstants.PathToUserEmail);

            await _mainWindowService.SendEmailMessage(userEmail);
        }

        /// <summary>
        /// Executes <see cref="OnTimeReached"/> method if target time is reached.
        /// </summary>
        /// <inheritdoc/>
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
