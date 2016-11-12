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

        public abstract Task<IEnumerable<Program>> Parse();

        protected async Task<HtmlDocument> Get()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(FeedUrl);
                response.EnsureSuccessStatusCode();

                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());
                return htmlDocument;
            }
        }
    }
}