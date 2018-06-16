using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix.Models.Vaio
{
    internal class F156 : Product
    {
        public override string Name => "VAIO Fit 15E | mk3";
        public override string ModelNumber => "VJF156*";
        public override string FeedUrl => "https://support.vaio.com/products/VJF156/update.html";
        public override string XPath => $"//dl[@class='information information-support']";
    }
}