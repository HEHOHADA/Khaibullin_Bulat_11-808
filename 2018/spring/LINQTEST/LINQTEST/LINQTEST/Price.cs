using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    public class Price
    {
        public readonly string ItemNumber;
        public readonly string NameShop;
        public readonly int RublePrice;

        public Price(string number, string name, int price)
        {
            ItemNumber = number;
            NameShop = name;
            RublePrice = price;
        }
    }
}
