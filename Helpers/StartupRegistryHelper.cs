using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R00ster.Helpers
{
    public static class StartupRegistryHelper
    {
        private const string AppName = "R00ster";
        private const string RegistryPath = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void RegisterInStartup()
        {
            var baseDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var exePath = Path.Combine(baseDir, $"{AppName}.exe");

            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath, true);
            if (key.GetValue(AppName) == null)
            {
                key.SetValue(AppName, $"\"{exePath}\" --background");
            }
        }

        public static void UnregisterFromStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath, true);

            if (key.GetValue(AppName) != null)
            {
                key.DeleteValue(AppName);
            }
        }
    }
}
