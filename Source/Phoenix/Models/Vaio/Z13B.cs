using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoenix.Models.Vaio
{
    internal class Z13B : Product
    {
        public override string Name => "VAIO Z フリップモデル";
        public override string ModelNumber => "VJZ13B*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz131/update.html";

        public override Task<IEnumerable<Program>> Parse()
        {
            throw new NotImplementedException();
        }
    }
}