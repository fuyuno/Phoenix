using System;
using System.IO;

using EnvSpecialFolder = System.Environment.SpecialFolder;

namespace Phoenix
{
    internal static class PhoenixConstants
    {
        public static string AppDirectory => Path.Combine(Environment.GetFolderPath(EnvSpecialFolder.ApplicationData), "kokoiroworks.com", ApplicationId);

        public static string ApplicationId { get; } = "Phoenix";

        public static string ConfigurationFile => Path.Combine(AppDirectory, "config.json");

        public static string ExecutableFile => Path.Combine(Directory.GetCurrentDirectory(), $"{ApplicationId}.exe");
    }
}