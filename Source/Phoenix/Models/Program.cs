using System;

namespace Phoenix.Models
{
    internal class Program
    {
        /// <summary>
        ///     更新プログラム名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     更新プログラム説明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     更新日
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        ///     DL ページ URL
        /// </summary>
        public string Url { get; set; }
    }
}