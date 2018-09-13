using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2zadacha
{
    class Program
    { 
        static void Main(string[] args)
        {// change number from abc to cba
            int num = Convert.ToInt32(Console.ReadLine());
            int changer = 0;
            for (int i = 0; i < 3; i++)
            {
                changer = ((changer * 10) + (num % 10));
                num = (num / 10);
            }
            Console.WriteLine(changer);
            Console.ReadKey();
        }
    }
}
