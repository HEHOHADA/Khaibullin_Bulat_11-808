using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loops4
{
    class Program
    {
        static void Main(string[] args)
        {
            var all = Convert.ToInt32(Console.ReadLine());
            int[] mas;
            int max = 0;
            int ch = 1;
            mas = new int[all];
            for (int i = 0; i<all ;i++)
            {
                mas[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(int i=1;i<all;i++)
            {
                if (mas[i - 1] == mas[i])
                    ch++;
                else if (max < ch)
                {
                    max = ch;
                    ch = 1;
                }
            }
            if (max < ch) max = ch;
            Console.WriteLine(max);
            Console.ReadKey();
        }
    }
}
