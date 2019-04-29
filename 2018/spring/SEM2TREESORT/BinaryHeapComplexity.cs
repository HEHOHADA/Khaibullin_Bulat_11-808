using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortTreeSem
{
    public class BinaryHeap<T, T1> where T : IComparable
    {
        private T[] heap;
        private T1[] items;

        public BinaryHeap(T[] heap, T1[] items)
        {
            this.heap = heap;
            this.items = items;
            BuildHeap();
        }

        private void Heapify(int index, int lastIndex)
        {
            int left = index * 2 + 1;
            int right = left + 1;
            int largest = index;
            if (left < lastIndex && heap[left].CompareTo(heap[largest]) > 0)
                largest = left;
            if (right < lastIndex && heap[right].CompareTo(heap[largest]) > 0)
                largest = right;
            if (largest != index)
            {
                Swap(heap, index, largest);
                Swap(items, index, largest);
                Heapify(largest, lastIndex);
            }
        }

        private void BuildHeap()
        {
            for (int i = heap.Length / 2 - 1; i >= 0; i--)
                Heapify(i, heap.Length);
        }
        public void Sort()
        {
            BuildHeap();
            for (int i = heap.Length - 1; i > 0; i--)
            {
                Swap(heap, 0, i);
                Swap(items, 0, i);
                Heapify(0, i);
            }
        }

        private void Swap(T[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private void Swap(T1[] array, int i, int j)
        {
            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

}
