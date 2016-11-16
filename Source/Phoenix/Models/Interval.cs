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
    }
}