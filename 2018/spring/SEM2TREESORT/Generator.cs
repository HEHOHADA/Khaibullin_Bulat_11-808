using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTreeSem
{
    public static class Generator
    {
        public static void Generete()
        {
            var rnd = new Random();
            var lines = new List<string>();
            for (int j = 1; j <= 100; j++)
                lines.Add(rnd.Next(100).ToString());
            File.WriteAllLines("data1.txt", lines);
            lines.Clear();
        }
    }
}
