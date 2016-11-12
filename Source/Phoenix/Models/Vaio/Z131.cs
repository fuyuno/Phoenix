using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phoenix.Models.Vaio
{
    internal class Z131 : Product
    {
        public override string Name => "VAIO Z クラムシェルモデル";
        public override string ModelNumber => "VJZ131*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz131/update.html";

        public override Task<IEnumerable<Program>> Parse()
        {
            return null;
        }
    }
}