using Microsoft.Win32;
using System.IO;

namespace R00ster.Helpers
{
    public static class StartupRegistryHelper
    {
        private const string AppName = "R00ster";
        private const string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        /// <summary>
        /// Registers the application to start automatically when the user logs in by adding a registry entry.
        /// </summary>
        /// <remarks>
        /// This method opens the registry key specified by <see cref="RegistryPath"/> and checks if an entry for the application name exists.
        /// If the entry does not exist, it constructs the path to the application's executable and adds it to the registry with the appropriate arguments to run in the background.
        /// </remarks>
        public static void RegisterInStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath, true);

            if (key.GetValue(AppName) == null)
            {
                var baseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var exePath = Path.Combine(baseDir, $"{AppName}.exe");

                key.SetValue(AppName, $"\"{exePath}\" --background");
            }
        }

        /// <summary>
        /// Unregisters the application from starting automatically by removing the corresponding registry entry.
        /// </summary>
        /// <remarks>
        /// This method opens the registry key specified by <see cref="RegistryPath"/> and deletes the registry entry associated with the application name,
        /// if it exists. This effectively prevents the application from starting automatically on user login.
        /// </remarks>
        public static void UnregisterFromStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath, true);

            if (key.GetValue(AppName) != null)
            {
                key.DeleteValue(AppName);
            }
        }
        /// <summary>
        /// Method to check is app background process is registered to auto start up.
        /// </summary>
        /// <returns>Returns true, if process is registered. Otherwise, false.</returns>
        public static bool IsRegisteredInStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath, true);
            return key.GetValue(AppName) != null;
        }
    }
}
