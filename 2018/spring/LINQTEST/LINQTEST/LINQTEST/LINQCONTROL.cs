using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    class LinqControl
    {// Task 1
        public static int[] GetThirdResidue(IEnumerable<int> aSequence)
        {
            return aSequence
                .Where(x => x / 3 != 1)
                .Select(x => x % 3 == 1 ? 2 * x : x)
                .ToArray();
        }
        // Task 3
        public static Tuple<string, int, int>[] FindAllInformation(Discount[] discount, Product[] product, PurchaseDetails[] details, Price[] price)
        {
            return product.Join(details, e => e.ItemNumber, o => o.ItemNumber, (o, e) => new
            {// соединяю все данные 
                e.ItemNumber,
                e.ConsumerCode,
                e.NameShop,
                o.Country,
                DetailsNumber = o.ItemNumber
            }).Join(discount, e => e.ConsumerCode, o => o.ConsumerCode, (e, o) => new
            {
                e.DetailsNumber,
                e.ConsumerCode,
                e.Country,
                e.ItemNumber,
                e.NameShop,
                o.DiscountInPercent,

            }).Join(price, e => e.ItemNumber, o => o.ItemNumber, (e, o) => new
            {
                e.DetailsNumber,
                e.ConsumerCode,
                e.Country,
                e.ItemNumber,
                e.NameShop,
                e.DiscountInPercent,
                o.RublePrice,
                priceIytemNumber = o.ItemNumber
            })// сортирую по нудным данным
            .OrderBy(x=>x.Country)
            .ThenBy(x=>x.ConsumerCode)// создаю тапл со всеми данными
            .Select(x => Tuple.Create(x.Country, x.RublePrice * x.DiscountInPercent, x.ConsumerCode))
            .ToArray();
        }
    }
    // Task 2
    public static class IEnumerableExtensions
    {
        public static IEnumerable<Tuple<T, T2>> TakeTuple<T, T2>(this IEnumerable<T> enumerable, IEnumerable<T2> enumerable2, Func<T, int> func)
        {
            foreach (var e in enumerable)
            {
                for (int i = 0; i < enumerable2.Count(); i++)
                    if (func(e) == i) yield return Tuple.Create(e, enumerable2.ElementAt(i));
                    else yield return Tuple.Create(e, default(T2));
            }
        }
    }


}
