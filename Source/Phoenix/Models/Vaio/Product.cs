using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using HtmlAgilityPack;

using Phoenix.Extensions;

namespace Phoenix.Models.Vaio
{
    internal abstract class Product
    {
        private static readonly List<Product> Products = new List<Product>
        {
            new C151(Windows.Windows7), //  2016/08 : VAIO C15
            new C151(Windows.Windows10), // 2016/08 : VAIO C15
            new F152(Windows.Windows7), //  2015/04 : VAIO Fit 15E | mk2
            new F152(Windows.Windows81), // 2015/04 : VAIO Fit 15E | mk2
            new F152(Windows.Windows10), // 2015/04 : VAIO Fit 15E | mk2
            new F156(), //                  2017/09 : VAIO Fit 15E | mk3
            new P132(Windows.Windows7), //  2015/05 : VAIO Pro 13 | mk2
            new P132(Windows.Windows81), // 2015/05 : VAIO Pro 13 | mk2
            new P132(Windows.Windows10), // 2015/05 : VAIO Pro 13 | mk2
            new S111(Windows.Windows7), //  2015/12 : VAIO S11
            new S111(Windows.Windows81), // 2015/12 : VAIO S11
            new S111(Windows.Windows10), // 2015/12 : VAIO S11
            new S112(), //                  2017/09 : VAIO S11
            new S131(Windows.Windows7), //  2016/02 : VAIO S13
            new S131(Windows.Windows81), // 2016/02 : VIAO S13
            new S131(Windows.Windows10), // 2016/02 : VAIO S13
            new S132(), //                  2017/09 : VAIO S13
            new S151(Windows.Windows7), //  2016/02 : VAIO S15
            new S151(Windows.Windows10), // 2016/02 : VAIO S15
            new S152(), //                  2017/09 : VAIO S15
            new Z12A(Windows.Windows7), //  2015/05 : VAIO Z Canvas
            new Z12A(Windows.Windows10), // 2015/05 : VAIO Z Canvas
            new Z131(Windows.Windows7), //  2016/02 : VAIO Z (Clamshell model)
            new Z131(Windows.Windows10), // 2016/02 : VAIO Z (Clamshell model)
            new Z13A(Windows.Windows81), // 2015/02 : VAIO Z
            new Z13A(Windows.Windows10), // 2015/02 : VAIO Z
            new Z13B() //                   2016/02 : VAIO Z (Flip model)
        };

        /// <summary>
        ///     製品名
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        ///     Windows
        /// </summary>
        public Windows Windows { get; protected set; } = Windows.Windows10;

        /// <summary>
        ///     型番
        /// </summary>
        public abstract string ModelNumber { get; }

        /// <summary>
        ///     サポートページ
        /// </summary>
        public abstract string FeedUrl { get; }

        /// <summary>
        ///     解析用 XPath
        /// </summary>
        public abstract string XPath { get; }

        /// <summary>
        ///     更新プログラム
        /// </summary>
        public List<Program> Softwares { get; }

        protected Product()
        {
            Softwares = new List<Program>();
        }

        public static Product Find(string name, Windows windows)
        {
            return Products.Single(w => w.ModelNumber.StartsWith(name) && w.Windows == windows);
        }

        public virtual async Task Parse()
        {
            var html = await Get();
            var documentNodes = html.DocumentNode.SelectSingleNode(XPath);

            foreach (var nodePair in documentNodes.ChildNodes.Where(w => w.Name == "dt" || w.Name == "dd").Chunk(2))
            {
                var nodes = nodePair.ToList();
                var info = nodes[1];
                var program = new Program
                {
                    Date = DateTime.Parse(nodes[0].InnerText),
                    Name = info.ChildNodes.First(w => w.Name == "a").InnerText,
                    Url = info.ChildNodes.First(w => w.Name == "a").Attributes["href"].Value,
                    Description = info.ChildNodes.Last().InnerText.Trim()
                };
                Softwares.Add(program);
            }
        }

        protected async Task<HtmlDocument> Get()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
                                                                         "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.87 Safari/537.36");
                var response = await httpClient.GetAsync(FeedUrl);
                response.EnsureSuccessStatusCode();

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());
                return htmlDocument;
            }
        }
    }
}