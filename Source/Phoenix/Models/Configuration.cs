namespace Phoenix.Models
{
    internal class Configuration
    {
        public Interval Interval { get; set; } = Interval.Daily;

        public Windows Windows { get; set; } = SystemInformation.GetOsVersion();

        public string ModelNumber { get; set; } = SystemInformation.GetModelNumber();
    }
}