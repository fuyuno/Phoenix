namespace Phoenix.Models.Vaio
{
    internal class S152 : Product
    {
        public override string Name => "VAIO S15";
        public override string ModelNumber => "VJS152*";
        public override string FeedUrl => "https://support.vaio.com/products/VJS152/update.html";
        public override string XPath => "//dl@[@class='information information-support']";
    }
}