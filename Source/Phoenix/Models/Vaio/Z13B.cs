using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Phoenix.Extensions;

namespace Phoenix.Models.Vaio
{
    internal class Z13B : Product
    {
        public override string Name => "VAIO Z フリップモデル";
        public override string ModelNumber => "VJZ13B*";
        public override string FeedUrl => "https://support.vaio.com/products/z-vjz131/update.html";

        public override async Task<IEnumerable<Program>> Parse()
        {
            var html = await Get();
            var documentNodes = html.DocumentNode
                                    .SelectSingleNode("//div[@id='tab1' and @class='tab-pane']//dl[@class='information information-support']");

            if (documentNodes.ChildNodes.Count % 2 != 0)
                throw new NotSupportedException("Cannot parse HTML document, please contact me.");

            var list = new List<Program>();
            foreach (var nodePair in documentNodes.ChildNodes.Chunk(2))
            {
                var nodes = nodePair.ToList();
                var info = nodes[1];
                var program = new Program
                {
                    Date = DateTime.Parse(nodes[0].InnerText),
                    Name = info.FirstChild.InnerText,
                    Url = info.FirstChild.Attributes["href"].Value,
                    Description = info.ChildNodes[2].InnerText
                };
                list.Add(program);
            }
            return list;
        }
    }
}