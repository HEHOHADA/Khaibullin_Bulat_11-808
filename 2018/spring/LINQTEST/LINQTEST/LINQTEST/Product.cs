using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    public class Product
    {
        public readonly string ItemNumber;
        public readonly string Category;
        public readonly string Country;

        public Product(string number, string category, string country)
        {
            ItemNumber = number;
            Category = category;
            Country = country;
        }
    }
}
