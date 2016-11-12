namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VJZ131
    /// </summary>
    internal class Z131 : Product
    {
        public override string Name => "VAIO Z クラムシェルモデル";
        public override string ModelNumber => "VJZ131*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz131/update.html";
        public override string XPath => "//div[@id='tab2']//dl[@class='information information-support']";
    }
}