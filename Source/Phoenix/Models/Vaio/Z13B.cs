namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO Z フリップモデル
    /// </summary>
    internal class Z13B : Product
    {
        public override string Name => "VAIO Z フリップモデル";
        public override string ModelNumber => "VJZ13B*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz131/update.html";
        public override string XPath => "//div[@id='tab1']//dl[@class='information information-support']";
    }
}