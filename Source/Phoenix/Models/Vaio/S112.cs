namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO S11
    /// </summary>
    internal class S112 : Product
    {
        public override string Name => "VAIO S12";
        public override string ModelNumber => "VJS112*";
        public override string FeedUrl => "https://support.vaio.com/products/VJS112/update.html";
        public override string XPath => "//dl@[@class='information information-support']";
    }
}