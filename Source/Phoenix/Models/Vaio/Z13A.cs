namespace Phoenix.Models.Vaio
{
    internal class Z13A : Product
    {
        private readonly string _windows;
        public override string Name => $"VAIO Z (Windows {_windows})";
        public override string ModelNumber => "VJZ13A*";
        public override string FeedUrl => "https://support.vaio.com/products/z/update.html";
        public override string XPath => $"//dl[@class='information information-support'][{(_windows == "10" ? 1 : 2)}]";

        public Z13A(string windows)
        {
            _windows = windows;
        }
    }
}