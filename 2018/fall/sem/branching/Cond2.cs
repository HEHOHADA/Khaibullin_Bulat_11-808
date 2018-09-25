using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cond2
{
    class Program
    {
        public static bool Compare(double side, int a, int b)
        {
            return side <= Math.Max(a, b);
        }

        static void Main(string[] args)
        {
            var x = Convert.ToInt32(Console.Read());
            var y = Convert.ToInt32(Console.Read());
            var z = Convert.ToInt32(Console.Read());
            var a = Convert.ToInt32(Console.Read());
            var b = Convert.ToInt32(Console.Read());
            int n = 0;
            if (Compare(x,a,b)) n++;
            if (Compare(y,a,b)) n++;
            if (Compare(z,a,b)) n++;
            if (n >= 2) Console.WriteLine("Влезет");
            else Console.WriteLine("Не влезет");
            Console.ReadKey();
        }
    }
}
