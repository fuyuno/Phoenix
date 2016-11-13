namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO S13
    /// </summary>
    internal class S131 : Product
    {
        public override string Name => $"VAIO S13 ({Windows.ToWinStr()})";
        public override string ModelNumber => "VJS131*";
        public override string FeedUrl => "https://support.vaio.com/products/s13/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex(1, 2, 3)}]";

        public S131(Windows windows)
        {
            Windows = windows;
        }
    }
}