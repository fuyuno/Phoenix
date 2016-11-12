namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VJZ12A (Windows 10)
    /// </summary>
    internal class Z12A10 : Product
    {
        public override string Name => "VAIO Z Canvas (Windows 10)";
        public override string ModelNumber => "VJZ12A*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz12A/update.html";
        public override string XPath => "//dl[@class='information information-support'][1]";
    }
}