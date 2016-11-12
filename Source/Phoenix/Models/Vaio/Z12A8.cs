namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VJZ12A (Windows 8.1)
    /// </summary>
    internal class Z12A8 : Product
    {
        public override string Name => "VAIO Z Canvas (Windows 8.1)";
        public override string ModelNumber => "VJZ12A*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz12A/update.html";
        public override string XPath => "//dl[@class='information information-support'][2]";
    }
}