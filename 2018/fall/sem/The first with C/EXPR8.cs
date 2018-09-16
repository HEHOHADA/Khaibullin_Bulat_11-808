using System;

namespace Expr8
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите x");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите y ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите а");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите b");
            double b = Convert.ToDouble(Console.ReadLine());
            //find free number of second line
            double b2 = y + (x / a);
            //find point of intersection
            double x1 = ((b2 - b) * a) / (a * a + 1);
            double y1 = (a * x1) + b;
            Console.WriteLine("x = "+x1+" y = "+y1);
            Console.ReadKey();
        }
    }
}