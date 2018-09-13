using System;


namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
            // Find numbers < than N. Use 2 simple numbers 
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());
            var count = (n / x) + (n / y) - (n / (x + y));
            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
