namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO Pro 13 | mk2
    /// </summary>
    internal class P132 : Product
    {
        public override string Name => "VAIO Pro 13 | mk2";
        public override string ModelNumber => "VJP132*";
        public override string FeedUrl => "https://support.vaio.com/products/pro-vjp132/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex(1, 2, 3)}]";

        public P132(Windows windows)
        {
            Windows = windows;
        }
    }
}