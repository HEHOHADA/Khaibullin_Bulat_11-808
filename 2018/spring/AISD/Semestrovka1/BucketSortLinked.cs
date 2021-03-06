﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace bucketlist
{
    public class BucketSortLinked
    {// счетчик
        static int iterationLinked = 0;

        public static int[] BucketSortWithLinked(int[] unsorted)
        {
            var buck = new List<LinkedList<int>>();
            var max = unsorted.Max();
            var min = unsorted.Min();
            var bucketCount = (int)Math.Sqrt(unsorted.Length);
            var bucketSize = (int)Math.Ceiling((max + 1 - min) / (decimal)bucketCount);
            for (int i = 0; i < bucketCount; i++)
            {
                buck.Add(new LinkedList<int>());
                iterationLinked++;
            }
            for (int i = 0; i < unsorted.Length; i++)
            {// загружаю по бакетам
                iterationLinked++;
                var number = unsorted[i];
                var bucketIndex = (number - min) / bucketSize;
                buck[bucketIndex].AddFirst(number);
            }
            foreach (var e in buck)
            {
                iterationLinked++;
                SortLinked(e);
            }
            // соединение в исходный массив
            return buck.SelectMany(x => x).ToArray();
        }

        private static void SortLinked(LinkedList<int> list)
        {// Сортировка листа
            var secondList = new LinkedList<int>();
            while (list.Count != 0)
            {
                iterationLinked++;
                var max = list.Max();
                secondList.AddFirst(max);
                list.Remove(max);
            }
            foreach (var e in secondList)
            {
                iterationLinked++;
                list.AddLast(e);
            }
        }

        public static void MeasureTimeItegration(int[] array, Func<int[], int[]> searchProcedure, Series series)
        {
            var watch = new Stopwatch();
            watch.Start();
                searchProcedure(array);
            watch.Stop();
            series.Points.Add(new DataPoint(array.Length,iterationLinked));
            iterationLinked = 0;
        }
    }
}
