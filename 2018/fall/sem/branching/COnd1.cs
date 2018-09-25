using System;

namespace cond1
{
    class Program
    {
        static void Main(string[] args)
        {// делим строку и  находим перемещение по вертикали и горизонтали
            string[] input = Console.ReadLine().Split();
            var dx = Math.Abs(Convert.ToInt32(input[1][0]) - Convert.ToInt32(input[0][0]));
            var dy = Math.Abs(Convert.ToInt32(input[1][1]) - Convert.ToInt32(input[0][1]));
            //рассматриваем для хода, все фигуры(кроме пешки)
            if (dx == dy && dy != 0 && dx != 0 || dx == 0 && dy != 0 || dy == 0 && dx != 0)
                Console.WriteLine("Для Ферзя");
            if ((dx<=1 &&dy<=1)&&(dx == dy && dy != 0 && dx != 0 || dx == 0 && dy != 0 || dy == 0 && dx != 0))
                Console.WriteLine("Для короля");
            if (dx==dy&& dx!=0)
                Console.WriteLine("Для слона");
            if (dx==2 && dy==1|| dx==1 && dy==2)
                Console.WriteLine("Для коня");
            if (dx!= 0 && dy==0 || dy!=0 && dx==0)
                Console.WriteLine("Для ладьи");
            else Console.WriteLine("не двигается");
            Console.ReadKey();
        }
    }
}
