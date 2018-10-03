using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cond4
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = Convert.ToInt32(Console.ReadLine());
            var b = Convert.ToInt32(Console.ReadLine());
            var c = Convert.ToInt32(Console.ReadLine());
            var d = Convert.ToInt32(Console.ReadLine());
            if (a == d)
                Console.WriteLine(a);
            else if (c == b)
                Console.WriteLine(b);
            else if (a < c && c < b && b < d)
                Console.WriteLine(c + "" + b);
            else if (a > c && a < d && b > d)
                Console.WriteLine(a + "" + d);
            else if (b > d && a < c)
                Console.WriteLine(c + "" + d);
            else if (d > b && c < a)
                Console.WriteLine(a + "" + b);
            else Console.WriteLine("не пересекается");
        }
    }
}
