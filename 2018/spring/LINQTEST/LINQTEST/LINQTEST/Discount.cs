using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    public class Discount
    {
        public readonly int ConsumerCode;
        public readonly string NameShop;
        public readonly int DiscountInPercent;

        public Discount(int code, string name, int discount)
        {
            ConsumerCode = code;
            NameShop = name;
            DiscountInPercent = discount;
        }
    }
}
