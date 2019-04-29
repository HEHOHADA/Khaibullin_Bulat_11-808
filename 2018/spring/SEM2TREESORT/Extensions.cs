using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SortTreeSem
{
    public static class Extensions
    {
        public static IEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector) where TKey : IComparable
        {
            var items = source.ToArray();
            var keys = items.Select(keySelector).ToArray();
            var heap = new BinaryHeap<TKey, TSource>(keys, items);
            heap.Sort();
            foreach (var item in items)
                yield return item;
        }
    }
}



