using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops2
{
    class Program
    {
        static void Main(string[] args)
        {
           var n = Convert.ToInt32(Console.ReadLine());
           if (n <= 14)
                Console.WriteLine(n * (n + 1) * 0.5);
           else Console.WriteLine((29 - n) * (28 - n) * 0.5);
           Console.ReadKey();
        }
    }
}
    

