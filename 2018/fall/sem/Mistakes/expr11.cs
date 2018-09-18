using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace expr11._1
{
    class Program
    {// Khaibullin Bulat ( programm find angle between hour and minute )
        static void Main(string[] args)
        {
            int angleHour = 30;
            int angleMinute = 6;
            var speedMinute = 1 / 2;
            Console.WriteLine("Ввод часов");
            var timeHour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввод минут");
            var timeMinute = Convert.ToInt32(Console.ReadLine());
            var endAngle = Math.Abs((timeHour * angleHour + speedMinute * timeMinute) - angleMinute * timeMinute);
            if (endAngle >180)
            {
                endAngle = endAngle - 180;
            }
            Console.WriteLine(endAngle);
            Console.ReadKey();

        }
    }
}
