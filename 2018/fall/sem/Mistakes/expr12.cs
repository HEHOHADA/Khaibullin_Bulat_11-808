using System;

namespace expr12
{
    class Program
    {//Khaibullin Bulat( combortable time in airplane)
        static void Main(string[] args)
        {
            var a = 0;
            var b = 0;
            Console.WriteLine("Введите данные h t v x");
            var h = Convert.ToInt32(Console.ReadLine());
            var t = Convert.ToInt32(Console.ReadLine());
            var v = Convert.ToInt32(Console.ReadLine());
            var x = Convert.ToInt32(Console.ReadLine());
            if (h-t*v<=0)
            {
                var minBadTime = (h - t * x) / (v - x);
                Console.WriteLine(minBadTime);
            }
            var maxBadTime = (h - t * x - t) / (x + 2);
            Console.WriteLine(maxBadTime);
            Console.ReadKey();
        }
    }
}
