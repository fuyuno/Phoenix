namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO Fit 15E | mk2
    /// </summary>
    internal class F152 : Product
    {
        public override string Name => "VAIO Fit 15E | mk2";
        public override string ModelNumber => "VJF152*";
        public override string FeedUrl => "https://support.vaio.com/products/fit-vjf152/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex(1, 2, 3)}]";

        public F152(Windows windows)
        {
            Windows = windows;
        }
    }
}