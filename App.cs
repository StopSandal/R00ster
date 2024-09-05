using R00ster.Helpers;
using System.Windows;

namespace R00ster
{
    /// <summary>
    /// Class that represents an application. 
    /// </summary>
    internal class App : Application
    {
        readonly MainWindow mainWindow;

        public App(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
