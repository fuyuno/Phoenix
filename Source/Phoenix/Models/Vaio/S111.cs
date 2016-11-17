namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO S11
    /// </summary>
    internal class S111 : Product
    {
        public override string Name => "VAIO S11";
        public override string ModelNumber => "VJS111*";
        public override string FeedUrl => "https://support.vaio.com/products/s11/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex(1, 2, 3)}]";

        public S111(Windows windows)
        {
            Windows = windows;
        }
    }
}