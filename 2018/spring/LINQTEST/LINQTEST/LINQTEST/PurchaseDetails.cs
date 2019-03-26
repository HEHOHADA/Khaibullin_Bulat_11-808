using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    public class PurchaseDetails
    {
        public readonly int ConsumerCode;
        public readonly string ItemNumber;
        public readonly string NameShop;

        public PurchaseDetails(int code, string number, string name)
        {
            ConsumerCode = code;
            ItemNumber = number;
            NameShop = name;
        }
    }
}
