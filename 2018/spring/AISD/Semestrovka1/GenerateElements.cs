using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bucketlist
{
    public class Generate
    {
        static Random random = new Random();
        public static void Generete()
        {
            var lines = new List<string>();
            for (int i = 1; i <= 100; i++)
            {// создание файла с элементам
                for (int j = 1; j < i * 100; j++)
                    lines.Add(random.Next(10000).ToString());
                File.WriteAllLines(string.Format("data{0}.txt", i), lines);
                lines.Clear();
            }
        }
    }
}
