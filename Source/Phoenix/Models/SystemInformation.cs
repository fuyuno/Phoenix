using System;
using System.Management;

namespace Phoenix.Models
{
    internal static class SystemInformation
    {
        public static string GetModelNumber()
        {
            using (var mos = new ManagementObjectSearcher())
            {
                mos.Query.QueryString = "SELECT * FROM Win32_ComputerSystemProduct";
                using (var moc = mos.Get())
                {
                    foreach (var mo in moc)
                        return (string) mo.Properties["Name"].Value;
                }
            }
            return "";
        }

        public static Windows GetOsVersion()
        {
            var version = Environment.OSVersion.Version;
            if (version.Major == 10)
                return Windows.Windows10;
            if (version.Major == 6 && version.Minor == 3)
                return Windows.Windows81;
            if (version.Major == 6 && version.Minor == 1)
                return Windows.Windows7;
            throw new NotSupportedException();
        }
    }
}