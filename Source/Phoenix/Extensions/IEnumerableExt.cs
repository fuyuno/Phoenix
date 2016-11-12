using System.Collections.Generic;
using System.Linq;

namespace Phoenix.Extensions
{
    internal static class IEnumerableExt
    {
        // http://stackoverflow.com/questions/419019/split-list-into-sublists-with-linq
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunkSize)
        {
            var enumerable = source as IList<T> ?? source.ToList();
            while (enumerable.Any())
            {
                yield return enumerable.Take(chunkSize);
                enumerable = enumerable.Skip(chunkSize).ToList();
            }
        }
    }
}