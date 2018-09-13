using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expr3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int h = Convert.ToInt32(Console.ReadLine());
            // REmove variat with anlge= 360
            if( h>12 )
            {
                h = h % 12;
            }
            var angle = h * 30;
            // Find less angle with Mhetod "abs"
            if (angle >= 180)
              {
                angle = Math.Abs(360 - angle);
              }
            Console.WriteLine(angle);
            Console.ReadKey();
        }
    }
}
