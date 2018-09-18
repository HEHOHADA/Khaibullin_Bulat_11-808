using System;

namespace expr10._1
{
    class Program
    { // Khaibullin Bulat (find sum <1000 /3 abd /5)
        static void Main(string[] args)
        {
            //find sum of number /3 + sum /5 and minus sum number /15
            var sumKr3 = (3 + 999) / 2 * 333;
            var sumKr5 = (5 + 995) / 2 * 199;
            var sumKr15 = (15 + 990) * 33;
            var endSum = sumKr3 + sumKr5 - sumKr15;
            Console.WriteLine(endSum);
            Console.ReadKey();
        }
    }    
}
