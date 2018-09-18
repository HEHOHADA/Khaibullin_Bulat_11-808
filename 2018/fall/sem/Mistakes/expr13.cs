using System;

namespace expr13
{
    class Program
    {//Khaibullin Bulat (goat and hay Square)
        static void Main(string[] args)
        {
            var a = Convert.ToInt32(Console.ReadLine());
            var r = Convert.ToInt32(Console.ReadLine());
            double sum = 0;
            if (r<=0.5*a)
            {
                sum = Math.PI * r * r;
            }
            if (r>=Math.Sqrt(2)/2*a)
            {
                sum = a * a;
            }
            if (r>0.5*a && r< Math.Sqrt(2) / 2 * a)
            {
                sum = (Math.PI * r * r )- 4 * (((((Math.PI * r * r) / 360) * 2 * Math.Acos((double)a / (2 * r)) * 180 / Math.PI)) - (Math.Sqrt(r * r - ((a * a) / 4)) * a / 2));
            }
            Console.WriteLine(Math.Round(sum,3));
            Console.ReadKey();
        }
    }
}
