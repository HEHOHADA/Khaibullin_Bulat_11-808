using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXPR6
{
    class Program
    {
        static void Main(string[] args)
        {
            var k = Convert.ToInt32(Console.ReadLine());
            var Per = (double)-1 / k;
            Console.WriteLine("Параллельной:(1; "+k+ ")");
            Console.WriteLine("Перпендикулярной:(1; "+Per+ ")");
            Console.ReadKey();
        }
    }
}
