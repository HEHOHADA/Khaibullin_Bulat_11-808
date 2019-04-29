using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SortTreeSem
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator.Generete();
            string[] input;
            string[] inp;
            input = File.ReadAllLines("data1.txt");
            inp = File.ReadAllLines("datatext.txt", System.Text.Encoding.Default);

            var array = new int[input.Length];
            for (int j = 0; j < input.Length; j++)
                array[j] = Convert.ToInt32(input[j]);
            var result = new BinaryHeap<int>(array);
            var list = inp.Select(x => x.Split(',')).ToList();
            var z = list.OrderBy(x => x[0]);
            foreach (var e in z)
            {
                foreach (var el in e)
                    Console.Write(el + " ");
                Console.WriteLine();
            }
            result.Sort();
            result.Write();
            Console.ReadKey();

        }
    }
}