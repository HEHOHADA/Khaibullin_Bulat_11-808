using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops1
{
    class Program
    {
        static void Main(string[] args)
        {
            var number = Convert.ToInt32(Console.ReadLine());
            var number2 = number;
            var count = 0;
            while(number >0)
            {
                number /= 10;
                count++;
            }
            //find count of number 
            var tenNumber = (int)Math.Pow(10, count-1);
            //first number*count of numbers
            while(number2>0)
            {
                number+= (number2 % 10)*tenNumber;
                number2 /= 10;
                tenNumber /= 10;
            }
            Console.WriteLine(number);
            Console.ReadKey();
        }
    }
}
