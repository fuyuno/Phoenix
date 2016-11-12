using System;

namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VJZ131
    /// </summary>
    internal class Z131 : Product
    {
        public override string Name => $"VAIO Z クラムシェルモデル ({Windows.ToWinStr()})";
        public override string ModelNumber => "VJZ131*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz131/update.html";
        public override string XPath => $"//div[@id='tab2']//dl[@class='information information-support'][{Windows.ToWinIndex()}]";

        public Z131(Windows windows)
        {
            if (windows == Windows.Windows81)
                throw new NotSupportedException("Support Windows 10 or 7 only.");
            Windows = windows;
        }
    }
}