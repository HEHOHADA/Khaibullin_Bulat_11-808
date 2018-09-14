using System;

namespace EXPR1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            //change a to b and b to a
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine(a, b);
            Console.ReadKey();
        }
    }
}