using System;
using System.IO;

using EnvSpecialFolder = System.Environment.SpecialFolder;

namespace Phoenix
{
    internal static class PhoenixConstants
    {
        private static readonly string AppName = "Phoenix";

        public static string AppDirectory => Path.Combine(Environment.GetFolderPath(EnvSpecialFolder.ApplicationData), "kokoiroworks.com", AppName);

        public static string ConfigurationFile => Path.Combine(AppDirectory, "config.json");
    }
}