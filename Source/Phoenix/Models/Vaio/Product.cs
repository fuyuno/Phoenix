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

        public virtual async Task Parse()
        {
            var html = await Get();
            var documentNodes = html.DocumentNode.SelectSingleNode(XPath);

            foreach (var nodePair in documentNodes.ChildNodes.Where(w => (w.Name == "dt") || (w.Name == "dd")).Chunk(2))
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