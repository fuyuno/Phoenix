using System;

namespace Phoenix.Models
{
    internal class Configuration
    {
        public Interval Interval { get; set; } = Interval.Daily;

        public DateTime CheckedAt { get; set; } = DateTime.MinValue;

        public Windows Windows { get; set; } = SystemInformation.GetOsVersion();

        public string ModelNumber { get; set; } = SystemInformation.GetModelNumber();
    }
}