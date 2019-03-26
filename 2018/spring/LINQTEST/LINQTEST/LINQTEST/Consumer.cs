using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTEST
{
    public class Consumer
    {
        public readonly int ConsumerCode;
        public readonly int Date;
        public readonly string Street;

        public Consumer(int code, int date, string street)
        {
            ConsumerCode = code;
            Date = date;
            Street = street;
        }
    }
}
