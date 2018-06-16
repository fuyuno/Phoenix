using System;

namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO S15
    /// </summary>
    internal class S151 : Product
    {
        public override string Name => "VAIO S15";
        public override string ModelNumber => "VJS151*";
        public override string FeedUrl => "https://support.vaio.com/products/s15/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex()}]";

        public S151(Windows windows)
        {
            if (windows == Windows.Windows81)
                throw new NotSupportedException();
            Windows = windows;
        }
    }
}