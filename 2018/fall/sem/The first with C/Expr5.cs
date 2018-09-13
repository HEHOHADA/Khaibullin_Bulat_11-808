using System;
namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int x = ((b / 4) - (b / 100) + (b / 400)) - ((a / 4) - (a / 100) + (a / 400));
            // add extra year if it the counter stars with a leap-year
            if ((a % 4 == 0 && a % 100 != 0 || a % 400 == 0))
            {
                x += 1;
            }
            Console.WriteLine(x);
            Console.ReadKey();
        }
    }
}
    

