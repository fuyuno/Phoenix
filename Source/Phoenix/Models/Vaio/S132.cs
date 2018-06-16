namespace Phoenix.Models.Vaio
{
    internal class S132 : Product
    {
        public override string Name => "VAIO S13";
        public override string ModelNumber => "VJS132*";
        public override string FeedUrl => "https://support.vaio.com/products/VJS132/update.html";
        public override string XPath => "//dl@[@class='information information-support']";
    }
}