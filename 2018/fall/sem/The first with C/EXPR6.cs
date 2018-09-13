using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXPR5
{
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = Convert.ToInt32(Console.ReadLine());
            var y1 = Convert.ToInt32(Console.ReadLine());
            var x2 = Convert.ToInt32(Console.ReadLine());
            var y2 = Convert.ToInt32(Console.ReadLine());
            var x3 = Convert.ToInt32(Console.ReadLine());
            var y3 = Convert.ToInt32(Console.ReadLine());
            var a = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            var b = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));
            var c = Math.Sqrt(Math.Pow((x3 - x2), 2) + Math.Pow((y3 - y2), 2));
            var p = (double)(a + b + c) / 2;
            var S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            var h = (double)(S * 2 / c);
            Console.WriteLine(h);
            Console.ReadKey();
        }
    }
}
