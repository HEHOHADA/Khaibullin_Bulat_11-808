using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cond5
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var parts = str.Split();
            var l = Convert.ToDouble(parts[0]);
            var k = Convert.ToDouble(parts[1]);
            var h = Convert.ToDouble(parts[2]);
            if (l%k>0)
            {
                Console.WriteLine(Math.Round(l/k*h+Double.Epsilon,5));
                Console.WriteLine(Math.Round(l / k * h+1 + Double.Epsilon, 5));
            }
            else
            {
                Console.WriteLine(Math.Round(l / k * h + Double.Epsilon, 5));
                Console.WriteLine(Math.Round(l / k * h + Double.Epsilon, 5));
            }
            Console.ReadKey();
        }
    }
}
