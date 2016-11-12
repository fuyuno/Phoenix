using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using HtmlAgilityPack;

namespace Phoenix.Models.Vaio
{
    internal abstract class Product
    {
        /// <summary>
        ///     製品名
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        ///     型番
        /// </summary>
        public abstract string ModelNumber { get; }

        /// <summary>
        ///     サポートページ
        /// </summary>
        public abstract string FeedUrl { get; }

        /// <summary>
        ///     更新プログラム
        /// </summary>
        public List<Program> Softwares { get; }

        protected Product()
        {
            Softwares = new List<Program>();
        }

        public abstract Task Parse();

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