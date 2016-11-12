using System;

namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VAIO Z
    /// </summary>
    internal class Z13A : Product
    {
        public override string Name => $"VAIO Z ({Windows})";
        public override string ModelNumber => "VJZ13A*";
        public override string FeedUrl => "https://support.vaio.com/products/z/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{Windows.ToWinIndex()}]";

        public Z13A(Windows windows)
        {
            if (windows == Windows.Windows7)
                throw new NotSupportedException();
        }
    }
}