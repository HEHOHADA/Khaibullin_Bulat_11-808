using System;

namespace COND3
{
    class Program
    {   //find number sum
        public static int Sum(int numb,int sum)
        {
            for (int i = 0; i<3; i++)
            {
                sum += numb % 10;
                numb = numb / 10;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            var number = Convert.ToInt32(Console.ReadLine());
            // lucky sum-1 and sum+1
            if ( Sum(number / 1000, 0) == Sum((number % 1000)-1, 0)  || Sum(number / 1000, 0) == Sum((number % 1000)+1, 0) )
                Console.WriteLine("Yes");
            else Console.WriteLine("No");
            Console.ReadKey();

        }
    }
}
