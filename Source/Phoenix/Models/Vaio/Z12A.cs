using System;

namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO Z Canvas
    /// </summary>
    internal class Z12A : Product
    {
        public override string Name => "VAIO Z Canvas";
        public override string ModelNumber => "VJZ12A*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz12A/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex()}]";

        public Z12A(Windows windows)
        {
            if (Windows == Windows.Windows7)
                throw new NotSupportedException();
            Windows = windows;
        }
    }
}