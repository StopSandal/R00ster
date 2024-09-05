namespace R00ster.Constants
{
    /// <summary>
    /// A bunch of constants with path at appsettings to values.
    /// </summary>
    internal static class SettingsPathConstants
    {
        internal const string PathToTimeOfExecuting = "NotificationSettings:FireTime";
        internal const string PathToUserEmail = "EmailSettings:UserEmail";
        internal const string PathToEmailSender = "EmailSettings:SenderEmail";
        internal const string PathToEmailSenderPassword = "EmailSettings:SenderPassword";
        internal const string PathToEmailSmtpServer = "EmailSettings:SmtpServer";
        internal const string PathToEmailSmtpPort = "EmailSettings:PortNumber";
        internal const string DatabaseConnectionPath = "DefaultConnection";
    }
}
