using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace bucketlist
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            var arrayGraph = new Series();
            var linkedGraph = new Series();
            string[] input;
            Generate.Generete();
            for (int i = 1; i <= 100; i++)
            {
                GC.Collect();
                input = File.ReadAllLines(string.Format("data{0}.txt", i));
                int[] array = new int[input.Length];
                for (int j = 0; j < input.Length; j++)
                    array[j] = Convert.ToInt32(input[j]);
                // поо два Графика, запускал отдельно
               //DrawGraph.MeasureTime(array, BucketSort.BucketSortWithArray, arrayGraph);
                //DrawGraph.MeasureTime(array, BucketSortLinked.BucketSortWithLinked, linkedGraph);
                BucketSort.MeasureTimeItegration(array, BucketSort.BucketSortWithArray, arrayGraph);
                BucketSortLinked.MeasureTimeItegration(array, BucketSortLinked.BucketSortWithLinked, linkedGraph);
            }
            var chart = DrawGraph.MakeChart(arrayGraph, linkedGraph);
            var form = new Form();
            form.ClientSize = new Size(800, 600);
            form.Controls.Add(chart);
            Application.Run(form);
        }        
    }

    public class BucketSort
    {
        static int iterationArray = 0;

        public static int[] BucketSortWithArray(int[] unsorted)
        {
            var max = unsorted.Max();// для дальшейшего создания бакетов
            var min = unsorted.Min();
            var bucketCount = (int)Math.Sqrt(unsorted.Length);// наиболее эффективное распределени
            var buck = new List<int>[bucketCount];
            var bucketSize = (int)Math.Ceiling((max + 1 - min) / (decimal)bucketCount);
            for (int i = 0; i < bucketCount; i++)
            {
                buck[i] = new List<int>();
                iterationArray++;
            }
            for (int i = 0; i < unsorted.Length; i++)
            {// по бакетам
                var number = unsorted[i];
                var bucketIndex = (number - min) / bucketSize;
                buck[bucketIndex].Add(number);
                iterationArray++;
            }

            foreach (var bucket in buck)
            {
                iterationArray++;
                bucket.Sort();
            }
            // соединение в исходный массив
            return buck.SelectMany(x => x).ToArray();
        }

        public static void MeasureTimeItegration(int[] array, Func<int[], int[]> searchProcedure, Series series)
        {
            var watch = new Stopwatch();
            watch.Start();
                searchProcedure(array);
            watch.Stop();
            series.Points.Add(new DataPoint(array.Length, iterationArray));
            iterationArray = 0;
        }

    }
}
