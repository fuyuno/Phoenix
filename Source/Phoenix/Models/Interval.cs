using System;

namespace Phoenix.Models
{
    internal enum Interval
    {
        Daily,

        Weekly,

        Monthly
    }

    internal static class IntervalExt
    {
        public static Interval ToInterval(int value)
        {
            switch (value)
            {
                case 0:
                    return Interval.Daily;

                case 1:
                    return Interval.Weekly;

                case 2:
                    return Interval.Monthly;

                default:
                    throw new ArgumentOutOfRangeException(nameof(value));
            }
        }

        public static int ToDays(this Interval obj)
        {
            switch (obj)
            {
                case Interval.Daily:
                    return 1;

                case Interval.Weekly:
                    return 7;

                case Interval.Monthly:
                    return 30;

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj));
            }
        }
    }
}