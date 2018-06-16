using System;

namespace Phoenix.Models
{
    internal enum Windows
    {
        /// <summary>
        ///     Windows 7
        /// </summary>
        Windows7,

        /// <summary>
        ///     Windows 8.1
        /// </summary>
        Windows81,

        /// <summary>
        ///     Windows 10
        /// </summary>
        Windows10
    }

    internal static class WindowsExt
    {
        public static string ToWinStr(this Windows obj)
        {
            switch (obj)
            {
                case Windows.Windows7:
                    return "Windows 7";

                case Windows.Windows81:
                    return "Windows 8.1";

                case Windows.Windows10:
                    return "Windows 10";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }

        public static int ToWinIndex(this Windows obj, params int[] indexes)
        {
            if (indexes.Length == 0)
                indexes = new[] {1, 2, 2};

            switch (obj)
            {
                case Windows.Windows10:
                    return indexes[0];

                case Windows.Windows81:
                    return indexes[1];

                case Windows.Windows7:
                    return indexes.Length == 3 ? indexes[2] : indexes[1];

                default:
                    return 1;
            }
        }
    }
}