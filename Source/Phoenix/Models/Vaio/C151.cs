using System;

namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO C15
    /// </summary>
    internal class C151 : Product
    {
        public override string Name => "VAIO C15";
        public override string ModelNumber => "VJC151*";
        public override string FeedUrl => "https://support.vaio.com/products/c15/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex()}]";

        public C151(Windows windows)
        {
            if (windows == Windows.Windows81)
                throw new NotSupportedException();
            Windows = windows;
        }
    }
}