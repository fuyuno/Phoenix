using System;

namespace Phoenix.Models.Vaio
{
    /// <summary>
    ///     VJZ12A
    /// </summary>
    internal class Z12A : Product
    {
        private readonly string _windows;
        public override string Name => $"VAIO Z Canvas (Windows {_windows})";
        public override string ModelNumber => "VJZ12A*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz12A/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{(_windows == "10" ? 1 : 2)}]";

        public Z12A(string windows)
        {
            if ((windows != "10") && (windows != "8.1"))
                throw new NotSupportedException("Supported 8.1 or 10 only.");
            _windows = windows;
        }
    }
}